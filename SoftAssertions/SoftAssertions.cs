using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;

namespace SoftAssertions
{
    public class SoftAssertions
    {
        private readonly List<SingleAssert> _verifications = new List<SingleAssert>();

        public void Add(string message, string expected, string actual)
        {
            _verifications.Add(new SingleAssert(message, expected, actual));
        }

        public void Add(string message, bool expected, bool actual)
        {
            Add(message, expected.ToString(), actual.ToString());
        }

        public void Add(string message, int expected, int actual)
        {
            Add(message, expected.ToString(), actual.ToString());
        }

        public void AddTrue(string message, bool actual)
        {
            _verifications.Add(new SingleAssert(message, true.ToString(), actual.ToString()));
        }

        public void AssertAll()
        {
            var failed = _verifications.Where(v => v.Failed).ToList();
            // TODO: Customise verification of add one from your favourite unit testing framework
            failed.Should().BeEmpty();
        }

        private class SingleAssert
        {
            private readonly string _message;
            private readonly string _expected;
            private readonly string _actual;

            public bool Failed { get; }

            public SingleAssert(string message, string expected, string actual)
            {
                _message = message;
                _expected = expected;
                _actual = actual;

                Failed = _expected != _actual;
                if (Failed)
                {
                    // TODO Do someting in case of failure, e.g. take screenshto
                    Console.WriteLine("Take screenshot");
                }
            }

            public override string ToString()
            {
                return $"'{_message}' assert was expected to be '{_expected}' but was '{_actual}'";
            }
        }
    }
}