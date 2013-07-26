﻿//
// PasswordDialog.cs
//
// Author(s): David Lechner <david@lechnology.com>
//
// Copyright (c) 2013 David Lechner
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Windows.Forms;

namespace dlech.SshAgentLib.WinForms
{
  partial class PasswordDialog : Form
  {

    private SecureEdit mSecureEdit;

    public SecureEdit SecureEdit
    {
      get
      {
        return mSecureEdit;
      }
    }

    public PasswordDialog()
    {
      InitializeComponent();
      mSecureEdit = new SecureEdit();
    }

    private void PasswordDialog_Load(object sender, EventArgs e)
    {
      mSecureEdit.Attach(passwordTextBox, null, true);
      Activate();
    }

    private void PasswordDialog_FormClosing(object sender, FormClosingEventArgs e)
    {
      mSecureEdit.Detach();
    }

    private void okButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
      Close();
    }

    protected override void OnShown(EventArgs e)
    {
      base.OnShown(e);
      passwordTextBox.Focus();
    }

  }
}
