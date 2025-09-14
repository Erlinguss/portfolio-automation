using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PortfolioAutomation.Models
{
    public class PortfolioData
    {
        public string BaseUrl { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(String.Format("BaseUrl{0}:", this.BaseUrl));
            return builder.ToString();
        }
    }
}
