﻿using NuGet.Versioning;
using System;

namespace NuGet
{
    public class PackageDependency
    {
        public PackageDependency(string id)
            : this(id, versionSpec: null)
        {
        }

        public PackageDependency(string id, IVersionSpec versionSpec) 
        {
            if (String.IsNullOrEmpty(id))
            {
                throw new ArgumentException(CommonResources.Argument_Cannot_Be_Null_Or_Empty, "id");
            }
            Id = id;
            VersionSpec = versionSpec;
        }

        public string Id
        {
            get;
            private set;
        }

        public IVersionSpec VersionSpec
        {
            get;
            private set;
        }

        public override string ToString()
        {
            if (VersionSpec == null)
            {
                return Id;
            }

            return Id + " " + VersionUtility.PrettyPrint(VersionSpec);
        }

        internal static PackageDependency CreateDependency(string id, string versionSpec)
        {
            return new PackageDependency(id, NuGet.Versioning.VersionSpec.ParseVersionSpec(versionSpec));
        }
    }
}