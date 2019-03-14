using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DrawerPrototype
{
    public partial class MainPage : ContentPage
    {
        bool isSlideOutInView;
        double slideOutScrollViewWidth;
        double addNewBtnWidth;

        public MainPage()
        {
            InitializeComponent();

            Debug.WriteLine("The Application is currently running on " + Device.RuntimePlatform);

            isSlideOutInView = false;

            Debug.WriteLine("in constructor (Global) but just after onAppearing(): The Width of the slideOutScroll View is " + slideOutScrollViewWidth + ".  The Width of the addNewBtn is " + addNewBtnWidth + ".  The total transition for AddNewBtn will be: " + -(slideOutScrollViewWidth - addNewBtnWidth));
            Debug.WriteLine("in constructor (current) but just after onAppearing(): The Width of the slideOutScroll View is " + slideOutScrollView.Width + ".  The Width of the addNewBtn is " + addNewBtn.Width + ".  The total transition for AddNewBtn will be: " + -(slideOutScrollView.Width - addNewBtn.Width));


        }

        async void OnAddNewBtnClicked(object sender, EventArgs args)
        {
            if (isSlideOutInView == false)
            {
                addNewBtn.IsEnabled = false;
                Debug.WriteLine("The Width of the slideOutScroll View is " +slideOutScrollViewWidth +".  The Width of the addNewBtn is " + addNewBtnWidth + ".  The total transition for AddNewBtn will be: " + -(slideOutScrollViewWidth - addNewBtnWidth));
                // animate the content to its original position (defined in corresponding xaml file)
                addNewBtn.TranslateTo(-(slideOutScrollViewWidth - addNewBtnWidth), 0, 1000);
                await slideOutScrollView.TranslateTo(0, 0, 1000);
                isSlideOutInView = true;
                addNewBtn.IsEnabled = true;
            }
            else
            {
                addNewBtn.IsEnabled = false;
                // animate the content out of view
                addNewBtn.TranslateTo(0, 0, 1000);
                await slideOutScrollView.TranslateTo(slideOutScrollView.Width, 0, 1000);
                isSlideOutInView = false;
                addNewBtn.IsEnabled = true;
            }

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //screenWidth = Application.Current.MainPage.Width;
            // set the content out of the bounds of the screen
            slideOutScrollViewWidth = slideOutScrollView.Width;
            addNewBtnWidth = addNewBtn.Width;
            Debug.WriteLine("in onAppearing() before TranslationX: The Width of the slideOutScroll View is " + slideOutScrollViewWidth + ".  The Width of the addNewBtn is " + addNewBtnWidth + ".  The total transition for AddNewBtn will be: " + -(slideOutScrollViewWidth - addNewBtnWidth));


            slideOutScrollView.TranslationX = slideOutScrollView.Width;
            slideOutScrollViewWidth = slideOutScrollView.Width;
            addNewBtnWidth = addNewBtn.Width;
            Debug.WriteLine("in onAppearing(): The Width of the slideOutScroll View is " + slideOutScrollViewWidth + ".  The Width of the addNewBtn is " + addNewBtnWidth + ".  The total transition for AddNewBtn will be: " + -(slideOutScrollViewWidth - addNewBtnWidth));
        }

    }
}
