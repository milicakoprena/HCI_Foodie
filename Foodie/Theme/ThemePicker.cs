
using Foodie.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Theme
{
    public class ThemePicker
    {
        public Color backgroundColor {  get; set; }
        public Color accentColor { get; set; }
        public Color fontColor { get; set; }
        public Image logo { get; set; }
        public Image eye { get; set; }
        public Image hidden { get; set; }
        public Image restaurant { get; set; }
        public Image cart { get; set; }

        private List<Color> backgroundColors = new List<Color> { 
            ColorTranslator.FromHtml("#f3dca4"), ColorTranslator.FromHtml("#ecf0f5"), ColorTranslator.FromHtml("#e5ead9")
        };

        private List<Color> accentColors = new List<Color>
        {
            ColorTranslator.FromHtml("#e59a5c"), ColorTranslator.FromHtml("#E6AACE"),  ColorTranslator.FromHtml("#a7ba81")
        };

        private List<Color> fontColors = new List<Color>
        {
            ColorTranslator.FromHtml("#713d12"), ColorTranslator.FromHtml("#213545"), ColorTranslator.FromHtml("#41521f")
        };

        private List<Image> logos = new List<Image>{ Resources.foodie_logo, Resources.logopink, Resources.logogreen };
        private List<Image> eyeImages = new List<Image> { Resources.eye, Resources.eyeblue, Resources.eyegreen};
        private List<Image> hiddenImages = new List<Image> { Resources.hidden, Resources.hideblue, Resources.hidegreen };
        private List<Image> restaurantImages = new List<Image> { Resources.restoran, Resources.res_blue, Resources.res_green };
        private List<Image> cartImages = new List<Image> { Resources.shopping_cart, Resources.cart_blue, Resources.cart_green };
        public void ChooseTheme(int themeValue)
        {
            int index = themeValue - 1;
            backgroundColor = backgroundColors.ElementAt(index);
            accentColor = accentColors.ElementAt(index);
            fontColor = fontColors.ElementAt(index);
            logo = logos.ElementAt(index);
            eye = eyeImages.ElementAt(index);
            hidden = hiddenImages.ElementAt(index);
            restaurant = restaurantImages.ElementAt(index);
            cart = cartImages.ElementAt(index);
        }
        

    }
}
