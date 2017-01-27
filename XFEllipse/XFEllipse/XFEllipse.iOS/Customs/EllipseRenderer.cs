using CoreGraphics;
using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFEllipse.Customs;
using XFEllipse.iOS.Customs;

[assembly: ExportRenderer(typeof(EllipseView), typeof(EllipseRenderer))]
namespace XFEllipse.iOS.Customs
{
    /// <summary>
    /// �b�o�̨ϥΤF ExportRenderer �ӧi�� Xamarin�A�ڭ̻ݭn�� EllipseRenderer ����ܥX EllipseView ���
    /// </summary>
    public class EllipseRenderer : VisualElementRenderer<EllipseView>
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == EllipseView.ColorProperty.PropertyName)
                this.SetNeedsDisplay(); // Force a call to Draw
        }

        public override void Draw(CGRect rect)
        {
            // �o�̱N�|�O�I�s iOS ��� API 
            using (var context = UIGraphics.GetCurrentContext())
            {
                var path = CGPath.EllipseFromRect(rect);
                context.AddPath(path);
                context.SetFillColor(this.Element.Color.ToCGColor());
                context.DrawPath(CGPathDrawingMode.Fill);
            }
        }
    }
}