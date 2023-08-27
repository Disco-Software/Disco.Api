namespace Disco.ApiServices.Test.Filters
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Disco.ApiServices.Filters;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Abstractions;
    using Microsoft.AspNetCore.Mvc.ActionConstraints;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Microsoft.AspNetCore.Mvc.Routing;
    using Microsoft.AspNetCore.Routing;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class GlobalExceptionFilterTests
    {
        private GlobalExceptionFilter _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new GlobalExceptionFilter();
        }

        [Test]
        public async Task CanCallOnExceptionAsync()
        {
            // Arrange
            var context = new ExceptionContext(new ActionContext
            {
                ActionDescriptor = new ActionDescriptor
                {
                    RouteValues = Substitute.For<IDictionary<string, string>>(),
                    AttributeRouteInfo = new AttributeRouteInfo
                    {
                        Template = "TestValue1026609205",
                        Order = 270540115,
                        Name = "TestValue1082338415",
                        SuppressLinkGeneration = false,
                        SuppressPathMatching = true
                    },
                    ActionConstraints = new[] { Substitute.For<IActionConstraintMetadata>(), Substitute.For<IActionConstraintMetadata>(), Substitute.For<IActionConstraintMetadata>() },
                    EndpointMetadata = new[] { new object(), new object(), new object() },
                    Parameters = new[] {
                        new ParameterDescriptor
                        {
                            Name = "TestValue1407553445",
                            ParameterType = typeof(string),
                            BindingInfo = new BindingInfo()
                        },
                        new ParameterDescriptor
                        {
                            Name = "TestValue612160065",
                            ParameterType = typeof(string),
                            BindingInfo = new BindingInfo()
                        },
                        new ParameterDescriptor
                        {
                            Name = "TestValue927377565",
                            ParameterType = typeof(string),
                            BindingInfo = new BindingInfo()
                        }
                    },
                    BoundProperties = new[] {
                        new ParameterDescriptor
                        {
                            Name = "TestValue439304928",
                            ParameterType = typeof(string),
                            BindingInfo = new BindingInfo()
                        },
                        new ParameterDescriptor
                        {
                            Name = "TestValue1658308941",
                            ParameterType = typeof(string),
                            BindingInfo = new BindingInfo()
                        },
                        new ParameterDescriptor
                        {
                            Name = "TestValue484519039",
                            ParameterType = typeof(string),
                            BindingInfo = new BindingInfo()
                        }
                    },
                    FilterDescriptors = new[] { new FilterDescriptor(Substitute.For<IFilterMetadata>(), 1618457356), new FilterDescriptor(Substitute.For<IFilterMetadata>(), 89885570), new FilterDescriptor(Substitute.For<IFilterMetadata>(), 130531833) },
                    DisplayName = "TestValue2136081343",
                    Properties = Substitute.For<IDictionary<object, object>>()
                },
                HttpContext = new DefaultHttpContext(),
                RouteData = new RouteData()
            }, new[] { Substitute.For<IFilterMetadata>(), Substitute.For<IFilterMetadata>(), Substitute.For<IFilterMetadata>() });

            // Act
            await _testClass.OnExceptionAsync(context);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallOnExceptionAsyncWithNullContext()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.OnExceptionAsync(default(ExceptionContext)));
        }
    }
}