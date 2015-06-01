﻿using Microsoft.DataTransfer.Basics;
using Microsoft.DataTransfer.DocumentDb.Client.Enumeration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.DataTransfer.DocumentDb.UnitTests.Source
{
    sealed class AsyncEnumeratorMock<T> : IAsyncEnumerator<T>
    {
        private IEnumerator<T> enumerator;

        public T Current
        {
            get { return enumerator.Current; }
        }

        public AsyncEnumeratorMock(IEnumerator<T> enumerator)
        {
            this.enumerator = enumerator;
        }

        public Task<bool> MoveNextAsync()
        {
            return Task.FromResult(enumerator.MoveNext());
        }

        public void Dispose()
        {
            TrashCan.Throw(ref enumerator);
        }
    }
}
