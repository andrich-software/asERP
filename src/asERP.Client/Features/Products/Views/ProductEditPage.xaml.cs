using System.Collections.Generic;
using System.IO;
using asERP.Client.Features.Products.Models;
using Microsoft.UI.Xaml.Controls;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace asERP.Client.Features.Products.Views;

public sealed partial class ProductEditPage : Page
{
    public ProductEditPage()
    {
        this.InitializeComponent();
    }

    private async void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is ProductEditModel model)
        {
            await model.CancelAsync();
        }
    }

    private async void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is ProductEditModel model)
        {
            await model.SaveAsync();
        }
    }

    private void AddAxis_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is ProductEditModel model)
        {
            model.AddAxis();
        }
    }

    private void RemoveAxis_Click(object sender, RoutedEventArgs e)
    {
        if (sender is FrameworkElement { DataContext: ProductAxisRow row } &&
            DataContext is ProductEditModel model)
        {
            model.RemoveAxis(row);
        }
    }

    private async void GenerateVariants_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is ProductEditModel model)
        {
            await model.GenerateVariantsAsync();
        }
    }

    private async void AddImage_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is not ProductEditModel model)
        {
            return;
        }

        var picker = new FileOpenPicker();
        picker.FileTypeFilter.Add(".jpg");
        picker.FileTypeFilter.Add(".jpeg");
        picker.FileTypeFilter.Add(".png");
        picker.FileTypeFilter.Add(".webp");
        picker.FileTypeFilter.Add(".gif");
        picker.FileTypeFilter.Add(".bmp");

        var files = await picker.PickMultipleFilesAsync();
        if (files == null || files.Count == 0)
        {
            return;
        }

        var uploads = new List<(Stream Stream, string FileName, string ContentType)>();
        foreach (var file in files)
        {
            var stream = await file.OpenStreamForReadAsync();
            uploads.Add((stream, file.Name, ResolveContentType(file)));
        }

        await model.AddImagesAsync(uploads);
    }

    private async void MakeImagePrimary_Click(object sender, RoutedEventArgs e)
    {
        if (sender is FrameworkElement { DataContext: ProductImageRow row } && DataContext is ProductEditModel model)
        {
            await model.MakeImagePrimaryAsync(row);
        }
    }

    private async void MoveImageUp_Click(object sender, RoutedEventArgs e)
    {
        if (sender is FrameworkElement { DataContext: ProductImageRow row } && DataContext is ProductEditModel model)
        {
            await model.MoveImageUpAsync(row);
        }
    }

    private async void MoveImageDown_Click(object sender, RoutedEventArgs e)
    {
        if (sender is FrameworkElement { DataContext: ProductImageRow row } && DataContext is ProductEditModel model)
        {
            await model.MoveImageDownAsync(row);
        }
    }

    private async void DeleteImage_Click(object sender, RoutedEventArgs e)
    {
        if (sender is FrameworkElement { DataContext: ProductImageRow row } && DataContext is ProductEditModel model)
        {
            await model.DeleteImageAsync(row);
        }
    }

    private static string ResolveContentType(StorageFile file)
    {
        if (!string.IsNullOrEmpty(file.ContentType))
        {
            return file.ContentType;
        }

        return file.FileType.ToLowerInvariant() switch
        {
            ".jpg" or ".jpeg" => "image/jpeg",
            ".png" => "image/png",
            ".webp" => "image/webp",
            ".gif" => "image/gif",
            ".bmp" => "image/bmp",
            _ => "application/octet-stream"
        };
    }
}
