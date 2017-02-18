using Foundation;
using System;
using UIKit;
using Plugin.Media;
using Plugin.Media.Abstractions;

using System.Threading.Tasks;


using CoreGraphics;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using Xamarin.Forms;

using Plugin.Media;
using Plugin.Media.Abstractions;

//using Microsoft.ProjectOxford.Vision;
//using Microsoft.ProjectOxford.Vision.Contract;
using System.ComponentModel;
using System.Diagnostics;

using static System.Diagnostics.Debug;
using System.Runtime.CompilerServices;


namespace FoodAcademy_HackNYU
{
	public partial class FirstViewController : UIViewController
	{


		public UIImagePickerController imagePicker = new UIImagePickerController();
		public UIImagePickerController takeImagePicker = new UIImagePickerController();


		Food food = new Food();

		//Command addInvoiceCommand = null;
		//public Command AddInvoiceCommand =>
		//			addInvoiceCommand ?? (addInvoiceCommand = new Command(async () => await ExecuteAddInvoiceCommandAsync()));


		//async Task ExecuteAddInvoiceCommandAsync()
		//{
		//	double total = 0.0;
		//	try
		//	{
		//		IsBusy = true;
		//		// 1. Add camera logic.
		//		await CrossMedia.Current.Initialize();

		//		MediaFile photo;
		//		if (CrossMedia.Current.IsCameraAvailable)
		//		{
		//			photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
		//			{
		//				Directory = "Receipts",
		//				Name = "Receipt"
		//			});
		//		}
		//		else
		//		{
		//			photo = await CrossMedia.Current.PickPhotoAsync();
		//		}

		//		if (photo == null)
		//		{
		//			PrintStatus("Photo was null :(");
		//			return;
		//		}


		//		// 2. Add  OCR logic.
		//		OcrResults text;

		//		var client = new VisionServiceClient("ebccaf8faed7407eb5b2108193d7b13a");

		//		using (var stream = photo.GetStream())
		//			text = await client.RecognizeTextAsync(stream);

		//		var numbers = from region in text.Regions
		//					  from line in region.Lines
		//					  from word in line.Words
		//					  where word?.Text?.Contains("$") ?? false
		//					  select word.Text.Replace("$", string.Empty);


		//		double temp = 0.0;
		//		total = numbers?.Count() > 0 ?
		//				numbers.Max(x => double.TryParse(x, out temp) ? temp : 0) :
		//				0;



		//		PrintStatus($"Found total {total.ToString("C")} " +
		//			$"and we had {text.Regions.Count()} regions");


		//		// 3. Add to data-bound collection.
		//		Invoices.Add(new Invoice
		//		{
		//			Total = total,
		//			Photo = photo.Path,
		//			TimeStamp = DateTime.Now
		//		});
		//	}
		//	catch (Exception ex)
		//	{
		//		await (Application.Current?.MainPage?.DisplayAlert("Error",
		//			$"Something bad happened: {ex.Message}", "OK") ??
		//			Task.FromResult(true));

		//		PrintStatus(string.Format("ERROR: {0}", ex.Message));

		//	}
		//	finally
		//	{
		//		IsBusy = false;
		//	}

		//}




		protected FirstViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}


		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);


			//profile View
			UITapGestureRecognizer tapGesture = new UITapGestureRecognizer(actionSheet);
			takePictureView.AddGestureRecognizer(tapGesture);
			//takePictureView.Image = food.image;
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.



	

			takePictureView.Layer.CornerRadius = takePictureView.Frame.Size.Width / 2;
			takePictureView.ClipsToBounds = true;

		}



		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		//photo Function
		public void addPhoto()
		{








			//imagePicker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;



			//imagePicker.MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary);


			//imagePicker.FinishedPickingMedia += Handle_FinishedPickingMedia;

		

			//imagePicker.Canceled += Handle_Canceled;

			//Console.WriteLine("Image selected");

			////this.NavigationController.PresentViewController(imagePicker, true, null);

			//NavigationController.PresentModalViewController(imagePicker, true);
			/// 
			/// 
			//var file = await CrossMedia.Current.PickPhotoAsync();

		
		}


		protected void Handle_FinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs e)
		{
			

			// determine what was selected, video or image
			bool isImage = false;
			switch (e.Info[UIImagePickerController.MediaType].ToString())
			{
				case "public.image":
					Console.WriteLine("Image selected");
					isImage = true;
					break;
				case "public.video":
					Console.WriteLine("Video selected");
					break;
			}

			// get common info (shared between images and video)
			NSUrl referenceURL = e.Info[new NSString("UIImagePickerControllerReferenceUrl")] as NSUrl;
			if (referenceURL != null)
				Console.WriteLine("Url:" + referenceURL.ToString());

			// if it was an image, get the other image info
			if (isImage)
			{
				// get the original image
				UIImage originalImage = e.Info[UIImagePickerController.OriginalImage] as UIImage;

				if (originalImage != null)
				{
					// do something with the image
					MaxResizeImage(originalImage, 8, 8); // resize image
					Console.WriteLine("got the original image");

					//profileView.Image = null;
					food.image = MaxResizeImage(originalImage, 200, 200); // display



				}
			}
			else { // if it's a video
				   // get video url
				NSUrl mediaURL = e.Info[UIImagePickerController.MediaURL] as NSUrl;
				if (mediaURL != null)
				{
					Console.WriteLine(mediaURL.ToString());
				}
			}

			imagePicker.DismissModalViewController(true);
		}

		void Handle_Canceled(object sender, EventArgs e)
		{
			
			imagePicker.DismissModalViewController(true);
		}

		public void takePicture()
		{
			takeImagePicker.SourceType = UIImagePickerControllerSourceType.Camera;
			takeImagePicker.MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.Camera);
			takeImagePicker.FinishedPickingMedia += Camera_FinishedPickingMedia;
			takeImagePicker.Canceled += Camera_Canceled;
			NavigationController.PresentModalViewController(takeImagePicker, true);

		}

		protected void Camera_FinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs e)
		{
			UIImage originalImage = e.Info[UIImagePickerController.OriginalImage] as UIImage;

			if (originalImage != null)
			{
				// do something with the image
				Console.WriteLine("got the original image");
				// resize image




				food.image = MaxResizeImage(originalImage, 200, 200); // display
			}
			takeImagePicker.DismissModalViewController(true);
		}

		void Camera_Canceled(object sender, EventArgs e)
		{
			//var imagePicker = new UIImagePickerController();
			takeImagePicker.DismissModalViewController(true);
		}



		public UIImage MaxResizeImage(UIImage sourceImage, float maxWidth, float maxHeight)
		{


			Console.WriteLine("Re Size original image");


			var sourceSize = sourceImage.Size;
			var maxResizeFactor = Math.Min(maxWidth / sourceSize.Width, maxHeight / sourceSize.Height);
			if (maxResizeFactor > 1) return sourceImage;
			var width = maxResizeFactor * sourceSize.Width;
			var height = maxResizeFactor * sourceSize.Height;
			UIGraphics.BeginImageContext(new CGSize(width, height));
			sourceImage.Draw(new CGRect(0, 0, width, height));
			var resultImage = UIGraphics.GetImageFromCurrentImageContext();
			UIGraphics.EndImageContext();
			return resultImage;
		}


		//actionSheet
		public void actionSheet()
		{


			//Action Sheet
			UIAlertController actionSheetAlert = UIAlertController.Create("Change Picture", "Select an item from below", UIAlertControllerStyle.ActionSheet);
			actionSheetAlert.AddAction(UIAlertAction.Create("Add Photo", UIAlertActionStyle.Default, (action) => addPhoto()));
			actionSheetAlert.AddAction(UIAlertAction.Create("Take Picture", UIAlertActionStyle.Default, (action) => takePicture()));
			actionSheetAlert.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, (action) => Console.WriteLine("Cancel button pressed.")));

			UIPopoverPresentationController presentationPopover = actionSheetAlert.PopoverPresentationController;
			if (presentationPopover != null)
			{
				presentationPopover.SourceView = this.View;
				presentationPopover.PermittedArrowDirections = UIPopoverArrowDirection.Up;
			}

			this.PresentViewController(actionSheetAlert, true, null);
		}
	}
}
