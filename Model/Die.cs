using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee3.Model
{
    class Die
    {
        Uri[] uriSource=new Uri[7];

        public Die()
        {

            uriSource[0] = new Uri((@"Resources/one.png"), UriKind.Relative);
            uriSource[1] = new Uri((@"Resources/one.png"), UriKind.Relative);
            uriSource[2] = new Uri((@"Resources/two.png"), UriKind.Relative);
            uriSource[3] = new Uri((@"Resources/three.png"), UriKind.Relative);
            uriSource[4] = new Uri((@"Resources/four.png"), UriKind.Relative);
            uriSource[5] = new Uri((@"Resources/five.png"), UriKind.Relative);
            uriSource[6] = new Uri((@"Resources/six.png"), UriKind.Relative);
        }

        public Uri[] Image
        {
            get
            {
                return uriSource;
            }
            set
            {
                 uriSource=value;
            }
        }


    }
}
