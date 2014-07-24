// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IoC.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.B
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using StructureMap;
using StructureMap.Graph;
using BlueLizard.Data.Interfaces;
using BlueLizard.Data.Repositories;
using BlueLizard.Domain;
using BlueLizard.Business;


namespace BlueLizard.Site.DependencyResolution {
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });
                            x.For<System.Data.Entity.DbContext>().Singleton().Use<BlueLizard.Data.Entities>();
                            x.For<BlueLizard.Data.Interfaces.IGenericDataRepository<Demo>>().Use<BlueLizard.Data.Repositories.GenericDataRepository<Demo>>();
                            x.For<BlueLizard.Data.Interfaces.IGenericDataRepository<Person>>().Use<BlueLizard.Data.Repositories.GenericDataRepository<Person>>();

                            x.For<BlueLizard.Business.Interfaces.IPersonManager>().Use<BlueLizard.Business.Managers.PersonManager>();


                        });
            return ObjectFactory.Container;
        }
    }
}