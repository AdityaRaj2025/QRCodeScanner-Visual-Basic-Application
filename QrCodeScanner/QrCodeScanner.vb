Imports WebCam_Capture
Imports MessagingToolkit.QRCode.Codec

Public Class QrCodeScanner
    WithEvents MyWebcam As WebCamCapture
    Dim reader As QRCodeDecoder
    Private Sub StartWebcam()
        Try
            StopWebcam()
            MyWebcam = New WebCamCapture
            MyWebcam.Start(0)
            MyWebcam.Start(0)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub StopWebcam()
        Try
            MyWebcam.Stop()
            MyWebcam.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        StartWebcam()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        StopWebcam()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Sacns the recived image
        Try
            StopWebcam()
            reader = New QRCodeDecoder
            TextBox1.Text = reader.decode(New Data.QRCodeBitmapImage(PictureBox1.Image))
            MsgBox("QR code is detected!..")
        Catch ex As Exception
            StartWebcam()

        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim SD As New SaveFileDialog
        SD.Filter = "PNG *.png"
        If SD.ShowDialog() = DialogResult.OK Then
            PictureBox1.Image.Save(SD.FileName, Imaging.ImageFormat.Png)
        End If
    End Sub

    Private Sub MyWebcam_ImageCaptured(source As Object, e As WebcamEventArgs) Handles MyWebcam.ImageCaptured
        PictureBox1.Image = e.WebCamImage
    End Sub
End Class
