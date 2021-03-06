﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using ContosoFieldService.PageModels;

namespace ContosoFieldService.Pages
{
    [XamlCompilation(XamlCompilationOptions.Skip)]
    public partial class JobDetailsPage : ContentPage
    {
        public JobDetailsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Setup map
            var pageModel = BindingContext as JobDetailsPageModel;
            if (pageModel?.Point?.Position?.Latitude != null && pageModel?.Point?.Position?.Longitude != null)
            {
                var pos = new Position(pageModel.Point.Position.Latitude, pageModel.Point.Position.Longitude);

                // Move map to point
                mapView.IsVisible = true;
                mapView.MoveToRegion(MapSpan.FromCenterAndRadius(pos, Distance.FromMiles(1)));

                // Add pin
                mapView.Pins.Add(new Pin
                {
                    Label = "Job",
                    Type = PinType.Place,
                    Position = pos
                });
            }
            else
            {
                // Hide map when no point is specified
                mapView.IsVisible = false;
            }
        }
    }
}
