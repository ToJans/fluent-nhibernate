﻿using System;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.MappingModel;
using FluentNHibernate.MappingModel.Collections;

namespace FluentNHibernate.Conventions.Instances
{
    public class BagInstance : BagInspector, IBagInstance
    {
        private readonly BagMapping mapping;
        public BagInstance(BagMapping mapping)
            : base(mapping)
        {
            this.mapping = mapping;
        }

        public void SetOrderBy(string orderBy)
        {
            if (mapping.IsSpecified(Attr.OrderBy))
                return;

            mapping.OrderBy = orderBy;
        }

        public new IAccessInstance Access
        {
            get
            {
                return new AccessInstance(value =>
                {
                    if (!mapping.IsSpecified(Attr.Access))
                        mapping.Access = value;
                });
            }
        }
    }
}
