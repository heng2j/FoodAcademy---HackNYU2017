// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace FoodAcademy_HackNYU
{
    [Register ("FirstViewController")]
    partial class FirstViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel AnalysisLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView SelectedPictureImageView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (AnalysisLabel != null) {
                AnalysisLabel.Dispose ();
                AnalysisLabel = null;
            }

            if (SelectedPictureImageView != null) {
                SelectedPictureImageView.Dispose ();
                SelectedPictureImageView = null;
            }
        }
    }
}