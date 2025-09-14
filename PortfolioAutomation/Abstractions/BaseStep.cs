using Microsoft.Playwright;
using Nest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioAutomation.Abstractions
{
    public abstract class BaseStep : IStep
    {
        protected readonly IRepository Repository;
        private IStep _next;

        protected BaseStep(IRepository repository, IStep next = null)
        {
            Repository = repository;
            _next = next;
        }

        public IStep Chain(IStep next)
        {
            if (_next == null)
            {
                _next = next;
            }
            else
            {
                var last = _next;
                while (last != null && last.GetNext() != null)
                {
                    last = last.GetNext();
                }

                last.SetNext(next);
            }
            return next;
        }

        public IStep GetNext() => _next;

        public void SetNext(IStep next) => _next = next;


        public async Task Execute()
        {
            var page = Repository.Get<Microsoft.Playwright.IPage>();

            await PerformExecute();

            if (_next != null)
            {
                await _next.Execute();
            }
        }
        protected abstract Task PerformExecute();
    }
}
