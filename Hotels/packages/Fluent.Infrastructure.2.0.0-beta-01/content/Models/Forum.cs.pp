//// -----------------------------------------------------------------------
//// <copyright file="Forum.cs" company="Fluent.Infrastructure">
////     Copyright © Fluent.Infrastructure. All rights reserved.
//// </copyright>
////-----------------------------------------------------------------------
/// This is a test file created by Fluent Infrastructure in order to 
/// illustrate its operation.
/// See more at: https://github.com/dn32/Fluent.Infrastructure/wiki
////-----------------------------------------------------------------------

using Fluent.Infrastructure.FluentAttribute;
using Fluent.Infrastructure.FluentModel;
using System;

namespace $rootnamespace$.Models
{
    [FluentMapTo(typeof(ForumForm))]
    public class Forum : BaseEntityClass
    {
        public string Description { get; set; }
        public DateTime UpdateDate { get; set; }
    }

    public class ForumForm : BaseEntityClass
    {
        public string Name { get; set; }
    }
}