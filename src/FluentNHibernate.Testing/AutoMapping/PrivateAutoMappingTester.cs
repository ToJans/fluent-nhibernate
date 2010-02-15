﻿using System;
using System.Collections.Generic;
using FluentNHibernate.Automapping;
using FluentNHibernate.MappingModel.ClassBased;
using FluentNHibernate.Utils.Reflection;
using FluentNHibernate.Testing.Utils;
using NUnit.Framework;
using System.Linq.Expressions;

namespace FluentNHibernate.Testing.Automapping
{
    [TestFixture]
    public class PrivateAutoMappingTester
    {
        private AutoPersistenceModel model;

        [Test]
        public void WillMapPrivatePropertyMatchingTheConvention()
        {
            Model<PrivateExampleClass>(p => p.Name.StartsWith("_"));

            Test<PrivateExampleClass>(mapping =>
                mapping.Properties.ShouldContain(x => x.Member == ReflectionHelper.GetMember(PrivateExampleClass.PrivateProperties.Property)));
        }

        [Test]
        public void DoNotMapPrivatePropertiesThatDoNotMatchConvention()
        {
            Model<PrivateExampleClass>(p => p.Name.StartsWith("asdf"));

            Test<PrivateExampleClass>(mapping =>
                mapping.Properties.ShouldBeEmpty());
        }

        [Test]
        public void CanMapPrivateCollection()
        {
            Model<PrivateExampleParent>(p => p.Name.StartsWith("_"));

            Test<PrivateExampleParent>(mapping =>
                mapping.Collections.ShouldContain(x => x.Member == ReflectionHelper.GetMember(PrivateExampleParent.PrivateProperties.Children)));
        }

        private void Model<T>(Func<Member, bool> convention)
        {
            model = new PrivateAutoPersistenceModel()
                .Setup(conventions => conventions.FindMappablePrivateProperties = convention);
            model.ValidationEnabled = false;
            model.AddTypeSource(new StubTypeSource(typeof(T)));
            model.BuildMappings();
        }

        private void Test<T>(Action<ClassMapping> mapping)
        {
            var map = model.FindMapping<T>();

            mapping(map.GetClassMapping());
        }
    }

    internal class PrivateExampleParent
    {
        private IList<PrivateExampleClass> _privateChildren { get; set; }

        public class PrivateProperties
        {
            public static Expression<Func<PrivateExampleParent, object>> Children = x => x._privateChildren;
        }
    }

    internal class PrivateExampleClass
    {
        private string _privateProperty { get; set; }

        public class PrivateProperties
        {
            public static Expression<Func<PrivateExampleClass, object>> Property = x => x._privateProperty;
        }
    }
}
