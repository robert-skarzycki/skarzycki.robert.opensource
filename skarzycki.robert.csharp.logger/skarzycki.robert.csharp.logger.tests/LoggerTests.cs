using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using skarzycki.robert.csharp.logger.lib;
using System;
using System.Reflection;
using NAssert = NUnit.Framework.Assert;
using System.Globalization;

namespace skarzycki.robert.csharp.logger.tests
{
    [TestClass]
    public class LoggerTests
    {
        [TestMethod]
        public void LogException_SHOULD_log_with_severity_Error()
        {
            var dummyException = new NullReferenceException();
            var fakeWriter = new Mock<ILogWriter>();

            var sut = new Logger(fakeWriter.Object);
            sut.LogException(dummyException);

            fakeWriter.Verify(m => m.Write(Match.Create<LogEntry>(e => e.Severity == Severity.Error)));
        }

        [TestMethod]
        public void LogException_SHOULD_not_throw_anything_if_TargetSite_is_null()
        {
            var dummyException = new NullTargetSiteFakeException();
            var fakeWriter = new Mock<ILogWriter>();
            
            var sut = new Logger(fakeWriter.Object);
            NAssert.DoesNotThrow(() => sut.LogException(dummyException));
        }

        [TestMethod]
        public void LogException_SHOULD_not_throw_anything_if_TargetSite_ReflectedType_is_null()
        {
            var dummyException = new NullReflectedTypeFakeException();
            var fakeWriter = new Mock<ILogWriter>();

            var sut = new Logger(fakeWriter.Object);
            NAssert.DoesNotThrow(() => sut.LogException(dummyException));
        }

        private class NullTargetSiteFakeException : Exception
        {
            public new MethodBase TargetSite { get { return null; } }
        }

        private class NullReflectedTypeFakeException : Exception
        {
            public new MethodBase TargetSite { get { return new FakeMethodBase(); } }

            private class FakeMethodBase : MethodBase
            {
                #region Not needed implementations

                public override MethodAttributes Attributes
                {
                    get
                    {
                        throw new NotImplementedException();
                    }
                }

                public override Type DeclaringType
                {
                    get
                    {
                        throw new NotImplementedException();
                    }
                }

                public override MemberTypes MemberType
                {
                    get
                    {
                        throw new NotImplementedException();
                    }
                }

                public override RuntimeMethodHandle MethodHandle
                {
                    get
                    {
                        throw new NotImplementedException();
                    }
                }

                public override string Name
                {
                    get
                    {
                        throw new NotImplementedException();
                    }
                }

                public override object[] GetCustomAttributes(bool inherit)
                {
                    throw new NotImplementedException();
                }

                public override object[] GetCustomAttributes(Type attributeType, bool inherit)
                {
                    throw new NotImplementedException();
                }

                public override MethodImplAttributes GetMethodImplementationFlags()
                {
                    throw new NotImplementedException();
                }

                public override ParameterInfo[] GetParameters()
                {
                    throw new NotImplementedException();
                }

                public override object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
                {
                    throw new NotImplementedException();
                }

                public override bool IsDefined(Type attributeType, bool inherit)
                {
                    throw new NotImplementedException();
                }

                #endregion

                public override Type ReflectedType { get { return null; } }                
            }
        }
    }
}
