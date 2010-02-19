using System;
using System.Linq;
using System.Linq.Expressions;
using FluentNHibernate.Automapping.TestFixtures;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.MappingModel;
using FluentNHibernate.MappingModel.ClassBased;
using FluentNHibernate.MappingModel.Collections;
using FluentNHibernate.Utils.Reflection;
using FluentNHibernate.Testing.Utils;
using NUnit.Framework;

namespace FluentNHibernate.Testing.ConventionsTests.Inspection
{
    [TestFixture, Category("Inspection DSL")]
    public class SubclassInspectorMapsToSubclassMapping
    {
        private SubclassMapping mapping;
        private ISubclassInspector inspector;

        [SetUp]
        public void CreateDsl()
        {
            mapping = new SubclassMapping();
            inspector = new SubclassInspector(mapping);
        }

        [Test]
        public void AbstractMapped()
        {
            mapping.Abstract = true;
            inspector.Abstract.ShouldEqual(true);
        }

        [Test]
        public void AbstractIsSet()
        {
            mapping.Abstract = true;
            inspector.IsSet(Attr.Abstract)
                .ShouldBeTrue();
        }

        [Test]
        public void AbstractIsNotSet()
        {
            inspector.IsSet(Attr.Abstract)
                .ShouldBeFalse();
        }

        [Test]
        public void AnysCollectionHasSameCountAsMapping()
        {
            mapping.AddAny(new AnyMapping());
            inspector.Anys.Count().ShouldEqual(1);
        }

        [Test]
        public void AnysCollectionOfInspectors()
        {
            mapping.AddAny(new AnyMapping());
            inspector.Anys.First().ShouldBeOfType<IAnyInspector>();
        }

        [Test]
        public void AnysCollectionIsEmpty()
        {
            inspector.Anys.IsEmpty().ShouldBeTrue();
        }

        [Test]
        public void CollectionsCollectionHasSameCountAsMapping()
        {
            mapping.AddCollection(new BagMapping());
            inspector.Collections.Count().ShouldEqual(1);
        }

        [Test]
        public void CollectionsCollectionOfInspectors()
        {
            mapping.AddCollection(new BagMapping());
            inspector.Collections.First().ShouldBeOfType<ICollectionInspector>();
        }

        [Test]
        public void CollectionsCollectionIsEmpty()
        {
            inspector.Collections.IsEmpty().ShouldBeTrue();
        }

        [Test]
        public void DiscriminatorValueMapped()
        {
            mapping.DiscriminatorValue = "value";
            inspector.DiscriminatorValue.ShouldEqual("value");
        }

        [Test]
        public void DiscriminatorValueIsSet()
        {
            mapping.DiscriminatorValue = "value";
            inspector.IsSet(Attr.DiscriminatorValue)
                .ShouldBeTrue();
        }

        [Test]
        public void DiscriminatorValueIsNotSet()
        {
            inspector.IsSet(Attr.DiscriminatorValue)
                .ShouldBeFalse();
        }

        [Test]
        public void DynamicInsertMapped()
        {
            mapping.DynamicInsert = true;
            inspector.DynamicInsert.ShouldEqual(true);
        }

        [Test]
        public void DynamicInsertIsSet()
        {
            mapping.DynamicInsert = true;
            inspector.IsSet(Attr.DynamicInsert)
                .ShouldBeTrue();
        }

        [Test]
        public void DynamicInsertIsNotSet()
        {
            inspector.IsSet(Attr.DynamicInsert)
                .ShouldBeFalse();
        }

        [Test]
        public void DynamicUpdateMapped()
        {
            mapping.DynamicUpdate = true;
            inspector.DynamicUpdate.ShouldEqual(true);
        }

        [Test]
        public void DynamicUpdateIsSet()
        {
            mapping.DynamicUpdate = true;
            inspector.IsSet(Attr.DynamicUpdate)
                .ShouldBeTrue();
        }

        [Test]
        public void DynamicUpdateIsNotSet()
        {
            inspector.IsSet(Attr.DynamicUpdate)
                .ShouldBeFalse();
        }

        [Test]
        public void ExtendsMapped()
        {
            mapping.Extends = "other-class";
            inspector.Extends.ShouldEqual("other-class");
        }

        [Test]
        public void ExtendsIsSet()
        {
            mapping.Extends = "other-class";
            inspector.IsSet(Attr.Extends)
                .ShouldBeTrue();
        }

        [Test]
        public void ExtendsIsNotSet()
        {
            inspector.IsSet(Attr.Extends)
                .ShouldBeFalse();
        }

        [Test]
        public void JoinsCollectionHasSameCountAsMapping()
        {
            mapping.AddJoin(new JoinMapping());
            inspector.Joins.Count().ShouldEqual(1);
        }

        [Test]
        public void JoinsCollectionOfInspectors()
        {
            mapping.AddJoin(new JoinMapping());
            inspector.Joins.First().ShouldBeOfType<IJoinInspector>();
        }

        [Test]
        public void JoinsCollectionIsEmpty()
        {
            inspector.Joins.IsEmpty().ShouldBeTrue();
        }

        [Test]
        public void LazyMapped()
        {
            mapping.Lazy = true;
            inspector.LazyLoad.ShouldEqual(true);
        }

        [Test]
        public void LazyIsSet()
        {
            mapping.Lazy = true;
            inspector.IsSet(Attr.Lazy)
                .ShouldBeTrue();
        }

        [Test]
        public void LazyIsNotSet()
        {
            inspector.IsSet(Attr.Lazy)
                .ShouldBeFalse();
        }

        [Test]
        public void NameMapped()
        {
            mapping.Name = "name";
            inspector.Name.ShouldEqual("name");
        }

        [Test]
        public void NameIsSet()
        {
            mapping.Name = "name";
            inspector.IsSet(Attr.Name)
                .ShouldBeTrue();
        }

        [Test]
        public void NameIsNotSet()
        {
            inspector.IsSet(Attr.Name)
                .ShouldBeFalse();
        }

        [Test]
        public void OneToOnesCollectionHasSameCountAsMapping()
        {
            mapping.AddOneToOne(new OneToOneMapping());
            inspector.OneToOnes.Count().ShouldEqual(1);
        }

        [Test]
        public void OneToOnesCollectionOfInspectors()
        {
            mapping.AddOneToOne(new OneToOneMapping());
            inspector.OneToOnes.First().ShouldBeOfType<IOneToOneInspector>();
        }

        [Test]
        public void OneToOnesCollectionIsEmpty()
        {
            inspector.OneToOnes.IsEmpty().ShouldBeTrue();
        }

        [Test]
        public void PropertiesCollectionHasSameCountAsMapping()
        {
            mapping.AddProperty(new PropertyMapping());
            inspector.Properties.Count().ShouldEqual(1);
        }

        [Test]
        public void PropertiesCollectionOfInspectors()
        {
            mapping.AddProperty(new PropertyMapping());
            inspector.Properties.First().ShouldBeOfType<IPropertyInspector>();
        }

        [Test]
        public void PropertiesCollectionIsEmpty()
        {
            inspector.Properties.IsEmpty().ShouldBeTrue();
        }

        [Test]
        public void ProxyMapped()
        {
            mapping.Proxy = "proxy";
            inspector.Proxy.ShouldEqual("proxy");
        }

        [Test]
        public void ProxyIsSet()
        {
            mapping.Proxy = "proxy";
            inspector.IsSet(Attr.Proxy)
                .ShouldBeTrue();
        }

        [Test]
        public void ProxyIsNotSet()
        {
            inspector.IsSet(Attr.Proxy)
                .ShouldBeFalse();
        }

        [Test]
        public void ReferencesCollectionHasSameCountAsMapping()
        {
            mapping.AddReference(new ManyToOneMapping());
            inspector.References.Count().ShouldEqual(1);
        }

        [Test]
        public void ReferencesCollectionOfInspectors()
        {
            mapping.AddReference(new ManyToOneMapping());
            inspector.References.First().ShouldBeOfType<IManyToOneInspector>();
        }

        [Test]
        public void ReferencesCollectionIsEmpty()
        {
            inspector.References.IsEmpty().ShouldBeTrue();
        }

        [Test]
        public void SelectBeforeUpdateMapped()
        {
            mapping.SelectBeforeUpdate = true;
            inspector.SelectBeforeUpdate.ShouldEqual(true);
        }

        [Test]
        public void SelectBeforeUpdateIsSet()
        {
            mapping.SelectBeforeUpdate = true;
            inspector.IsSet(Attr.SelectBeforeUpdate)
                .ShouldBeTrue();
        }

        [Test]
        public void SelectBeforeUpdateIsNotSet()
        {
            inspector.IsSet(Attr.SelectBeforeUpdate)
                .ShouldBeFalse();
        }

        [Test]
        public void SubclassesCollectionHasSameCountAsMapping()
        {
            mapping.AddSubclass(new SubclassMapping());
            inspector.Subclasses.Count().ShouldEqual(1);
        }

        [Test]
        public void SubclassesCollectionOfInspectors()
        {
            mapping.AddSubclass(new SubclassMapping());
            inspector.Subclasses.First().ShouldBeOfType<ISubclassInspector>();
        }

        [Test]
        public void SubclassesCollectionIsEmpty()
        {
            inspector.Subclasses.IsEmpty().ShouldBeTrue();
        }

        [Test]
        public void TypeMapped()
        {
            mapping.Type = typeof(ExampleClass);
            inspector.Type.ShouldEqual(typeof(ExampleClass));
        }

        [Test]
        public void TypeIsSet()
        {
            mapping.Type = typeof(ExampleClass);
            inspector.IsSet(Attr.Type)
                .ShouldBeTrue();
        }

        [Test]
        public void TypeIsNotSet()
        {
            inspector.IsSet(Attr.Type)
                .ShouldBeFalse();
        }

        #region Helpers

        private Member Prop(Expression<Func<ISubclassInspector, object>> propertyExpression)
        {
            return ReflectionHelper.GetMember(propertyExpression);
        }

        #endregion
    }
}