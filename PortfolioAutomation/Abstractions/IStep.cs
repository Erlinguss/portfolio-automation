using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PortfolioAutomation.Abstractions
{
    public interface IStep
    {
        Task Execute();
        IStep Chain(IStep next);
        IStep GetNext();
        void SetNext(IStep next);
    }
}
