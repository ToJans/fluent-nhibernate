using System;
using FluentNHibernate.Mapping;
using FluentNHibernate.Testing.Utils;
using NUnit.Framework;

namespace FluentNHibernate.Testing.DomainModel.Mapping
{
	[TestFixture]
	public class FetchBuilderTester
	{
		#region Test Setup
		public FetchBuilder<object> _fetchType;
	    private string fetchValue;
		
		[SetUp]
		public virtual void SetUp()
		{
		    fetchValue = "";
			_fetchType = new FetchBuilder<object>(null, new FetchBuilder(value => fetchValue = value));
		}

		protected FetchBuilderTester A_call_to(Func<object> fetchAction)
		{
			fetchAction();
			return this;
		}

		private void should_set_the_fetch_value_to(string expected)
		{
			fetchValue.ShouldEqual(expected);
		}

		#endregion

		[Test]
		public void Join_should_add_the_correct_fetch_attribute_to_the_parent_part()
		{
			A_call_to(_fetchType.Join).should_set_the_fetch_value_to("join");
		}

		[Test]
		public void Select_should_add_the_correct_fetch_attribute_to_the_parent_part()
		{
			A_call_to(_fetchType.Select).should_set_the_fetch_value_to("select");
		}

        [Test]
        public void Subselect_should_add_the_correct_fetch_attribute_to_the_parent_part()
        {
            A_call_to(_fetchType.Subselect).should_set_the_fetch_value_to("subselect");
        }
	}
}
