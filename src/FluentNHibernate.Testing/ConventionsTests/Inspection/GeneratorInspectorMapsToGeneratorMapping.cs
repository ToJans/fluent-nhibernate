using System;
using System.Linq.Expressions;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.MappingModel;
using FluentNHibernate.MappingModel.Identity;
using FluentNHibernate.Utils.Reflection;
using FluentNHibernate.Testing.Utils;
using NUnit.Framework;

namespace FluentNHibernate.Testing.ConventionsTests.Inspection
{
    [TestFixture, Category("Inspection DSL")]
    public class GeneratorInspectorMapsToGeneratorMapping
    {
        private GeneratorMapping mapping;
        private IGeneratorInspector inspector;

        [SetUp]
        public void CreateDsl()
        {
            mapping = new GeneratorMapping();
            inspector = new GeneratorInspector(mapping);
        }

        [Test]
        public void ClassMapped()
        {
            mapping.Class = "class";
            inspector.Class.ShouldEqual("class");
        }

        [Test]
        public void ClassIsSet()
        {
            mapping.Class = "class";
            inspector.IsSet(Attr.Class)
                .ShouldBeTrue();
        }

        [Test]
        public void ClassIsNotSet()
        {
            inspector.IsSet(Attr.Class)
                .ShouldBeFalse();
        }

        [Test]
        public void ParamsHasSameCountAsMapping()
        {
            mapping.Params.Add("one", "value");
            inspector.Params.Count.ShouldEqual(1);
        }

        [Test]
        public void ParamsIsEmpty()
        {
            inspector.Params.IsEmpty().ShouldBeTrue();
        }

        #region Helpers

        private Member Prop(Expression<Func<IGeneratorInspector, object>> propertyExpression)
        {
            return ReflectionHelper.GetMember(propertyExpression);
        }

        #endregion
    }
}