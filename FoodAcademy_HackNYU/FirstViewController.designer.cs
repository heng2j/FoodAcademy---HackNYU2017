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
        UIKit.UIImageView takePictureView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (takePictureView != null) {
                takePictureView.Dispose ();
                takePictureView = null;
            }
        }
    }
}