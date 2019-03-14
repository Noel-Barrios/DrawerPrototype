using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DrawerPrototype
{
    public partial class MainPage : ContentPage
    {
        bool isSlideOutInView;

        public MainPage()
        {

            InitializeComponent();
        }

        async void OnAddNewBtnClicked(object sender, EventArgs args)
        {
            if (isSlideOutInView == false)
            {
                addNewbtn.IsEnabled = false;
                // animate the content to its original position (defined in corresponding xaml file)
                addNewbtn.TranslateTo(-(slideOutScrollView.Width - addNewbtn.Width), 0, 1000);
                await slideOutScrollView.TranslateTo(0, 0, 1000);
                isSlideOutInView = true;
                addNewbtn.IsEnabled = true;
            }
            else
            {
                addNewbtn.IsEnabled = false;
                // animate the content out of view
                addNewbtn.TranslateTo(0, 0, 1000);
                await slideOutScrollView.TranslateTo(slideOutScrollView.Width, 0, 1000);
                isSlideOutInView = false;
                addNewbtn.IsEnabled = true;
            }

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //screenWidth = Application.Current.MainPage.Width;
            // set the content out of the bounds of the screen
            slideOutScrollView.TranslationX = (slideOutScrollView.Width);
            isSlideOutInView = false;

        }

    }
}
