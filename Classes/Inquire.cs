using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VTI_EVAC_AND_SINGLE_CHARGE.Forms;
using VTIWindowsControlLibrary.Forms;
using System.Windows.Forms;

namespace VTI_EVAC_AND_SINGLE_CHARGE.Classes
{
  /// <summary>
  /// Represents the <see cref="VTIWindowsControlLibrary.Forms.InquireForm">Inquire Form</see> of the client application
  /// </summary>
  /// <remarks>
  /// This class isn't the <see cref="VTIWindowsControlLibrary.Forms.InquireForm">Inquire Form</see> itself, but contains a
  /// private static instance of it, and has static methods for accessing it.
  /// </remarks>
  public class Inquire2
  {
    private static InquireForm2 inquireForm;

    /// <summary>
    /// Initializes the static instance of the <see cref="VTIWindowsControlLibrary.Forms.InquireForm">Inquire Form</see> class
    /// </summary>
    static Inquire2()
    {
      inquireForm = new InquireForm2();
    }

    /// <summary>
    /// Shows the <see cref="VTIWindowsControlLibrary.Forms.InquireForm">Inquire Form</see>
    /// </summary>
    public static void Show()
    {
      Show(null);
    }

    /// <summary>
    /// Shows the <see cref="VTIWindowsControlLibrary.Forms.InquireForm">Inquire Form</see>
    /// </summary>
    /// <param name="MdiParent">Form that will own this form.</param>
    public static void Show(Form MdiParent)
    {
      if (MdiParent != null)
        inquireForm.MdiParent = MdiParent;
      inquireForm.Show();
      inquireForm.BringToFront();
    }

    /// <summary>
    /// Hides the <see cref="VTIWindowsControlLibrary.Forms.InquireForm">Inquire Form</see>
    /// </summary>
    public static void Hide()
    {
      inquireForm.Hide();
    }

    /// <summary>
    /// Causes the inquire form to find all data related to the specified serial number.
    /// </summary>
    /// <param name="SerialNumber">Serial number to look up</param>
    public static void LookupSerialNumber(string SerialNumber)
    {
      inquireForm.LookupSerialNumber(SerialNumber);
    }

  }
}
