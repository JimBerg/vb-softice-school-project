<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.lblDragAreaCoinInput = New System.Windows.Forms.Label()
        Me.lblHiddenField = New System.Windows.Forms.Label()
        Me.trkBarSize = New System.Windows.Forms.TrackBar()
        Me.lblBadTaste = New System.Windows.Forms.Label()
        Me.txtSelection = New System.Windows.Forms.TextBox()
        Me.picIceOutput = New System.Windows.Forms.PictureBox()
        Me.btnGiveMeMyIce = New System.Windows.Forms.Button()
        Me.pnlGroupFlavor = New System.Windows.Forms.Panel()
        Me.radFlavorVanillaExtra = New System.Windows.Forms.RadioButton()
        Me.radFlavorChocolate = New System.Windows.Forms.RadioButton()
        Me.radFlavorSpinach = New System.Windows.Forms.RadioButton()
        Me.radFlavorRaspberry = New System.Windows.Forms.RadioButton()
        Me.radFlavorVanilla = New System.Windows.Forms.RadioButton()
        CType(Me.trkBarSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picIceOutput, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGroupFlavor.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblDragAreaCoinInput
        '
        Me.lblDragAreaCoinInput.AllowDrop = True
        Me.lblDragAreaCoinInput.BackColor = System.Drawing.Color.Gray
        Me.lblDragAreaCoinInput.Image = CType(resources.GetObject("lblDragAreaCoinInput.Image"), System.Drawing.Image)
        Me.lblDragAreaCoinInput.Location = New System.Drawing.Point(457, 12)
        Me.lblDragAreaCoinInput.Name = "lblDragAreaCoinInput"
        Me.lblDragAreaCoinInput.Size = New System.Drawing.Size(12, 98)
        Me.lblDragAreaCoinInput.TabIndex = 1
        '
        'lblHiddenField
        '
        Me.lblHiddenField.AllowDrop = True
        Me.lblHiddenField.AutoSize = True
        Me.lblHiddenField.Location = New System.Drawing.Point(468, 602)
        Me.lblHiddenField.Name = "lblHiddenField"
        Me.lblHiddenField.Size = New System.Drawing.Size(21, 13)
        Me.lblHiddenField.TabIndex = 2
        Me.lblHiddenField.Text = "0|0"
        Me.lblHiddenField.Visible = False
        '
        'trkBarSize
        '
        Me.trkBarSize.AutoSize = False
        Me.trkBarSize.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(199, Byte), Integer), CType(CType(187, Byte), Integer))
        Me.trkBarSize.LargeChange = 1
        Me.trkBarSize.Location = New System.Drawing.Point(27, 402)
        Me.trkBarSize.Maximum = 5
        Me.trkBarSize.Minimum = 1
        Me.trkBarSize.Name = "trkBarSize"
        Me.trkBarSize.Size = New System.Drawing.Size(228, 30)
        Me.trkBarSize.TabIndex = 6
        Me.trkBarSize.Value = 3
        '
        'lblBadTaste
        '
        Me.lblBadTaste.AutoSize = True
        Me.lblBadTaste.Location = New System.Drawing.Point(149, 420)
        Me.lblBadTaste.Name = "lblBadTaste"
        Me.lblBadTaste.Size = New System.Drawing.Size(0, 13)
        Me.lblBadTaste.TabIndex = 12
        Me.lblBadTaste.Visible = False
        '
        'txtSelection
        '
        Me.txtSelection.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.txtSelection.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSelection.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtSelection.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSelection.Enabled = False
        Me.txtSelection.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.txtSelection.ForeColor = System.Drawing.Color.PaleGoldenrod
        Me.txtSelection.Location = New System.Drawing.Point(30, 48)
        Me.txtSelection.Multiline = True
        Me.txtSelection.Name = "txtSelection"
        Me.txtSelection.ReadOnly = True
        Me.txtSelection.Size = New System.Drawing.Size(389, 91)
        Me.txtSelection.TabIndex = 13
        Me.txtSelection.Text = "STATUS: Bitte wählen und bestätigen." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Sorte: ---" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Grösse: ---" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Preis: ---" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "gezahl" & _
            "t: --- "
        '
        'picIceOutput
        '
        Me.picIceOutput.BackColor = System.Drawing.Color.Transparent
        Me.picIceOutput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picIceOutput.Image = CType(resources.GetObject("picIceOutput.Image"), System.Drawing.Image)
        Me.picIceOutput.Location = New System.Drawing.Point(265, 161)
        Me.picIceOutput.Name = "picIceOutput"
        Me.picIceOutput.Size = New System.Drawing.Size(205, 301)
        Me.picIceOutput.TabIndex = 14
        Me.picIceOutput.TabStop = False
        '
        'btnGiveMeMyIce
        '
        Me.btnGiveMeMyIce.Image = CType(resources.GetObject("btnGiveMeMyIce.Image"), System.Drawing.Image)
        Me.btnGiveMeMyIce.Location = New System.Drawing.Point(448, 118)
        Me.btnGiveMeMyIce.Name = "btnGiveMeMyIce"
        Me.btnGiveMeMyIce.Size = New System.Drawing.Size(25, 25)
        Me.btnGiveMeMyIce.TabIndex = 10
        Me.btnGiveMeMyIce.UseVisualStyleBackColor = True
        '
        'pnlGroupFlavor
        '
        Me.pnlGroupFlavor.BackColor = System.Drawing.Color.Transparent
        Me.pnlGroupFlavor.Controls.Add(Me.radFlavorVanillaExtra)
        Me.pnlGroupFlavor.Controls.Add(Me.radFlavorChocolate)
        Me.pnlGroupFlavor.Controls.Add(Me.radFlavorSpinach)
        Me.pnlGroupFlavor.Controls.Add(Me.radFlavorRaspberry)
        Me.pnlGroupFlavor.Controls.Add(Me.radFlavorVanilla)
        Me.pnlGroupFlavor.Location = New System.Drawing.Point(30, 191)
        Me.pnlGroupFlavor.Name = "pnlGroupFlavor"
        Me.pnlGroupFlavor.Size = New System.Drawing.Size(225, 185)
        Me.pnlGroupFlavor.TabIndex = 15
        '
        'radFlavorVanillaExtra
        '
        Me.radFlavorVanillaExtra.AutoSize = True
        Me.radFlavorVanillaExtra.Location = New System.Drawing.Point(15, 55)
        Me.radFlavorVanillaExtra.Name = "radFlavorVanillaExtra"
        Me.radFlavorVanillaExtra.Size = New System.Drawing.Size(113, 17)
        Me.radFlavorVanillaExtra.TabIndex = 9
        Me.radFlavorVanillaExtra.Text = "Vanille mit Streusel"
        Me.radFlavorVanillaExtra.UseVisualStyleBackColor = True
        '
        'radFlavorChocolate
        '
        Me.radFlavorChocolate.AutoSize = True
        Me.radFlavorChocolate.Location = New System.Drawing.Point(15, 124)
        Me.radFlavorChocolate.Name = "radFlavorChocolate"
        Me.radFlavorChocolate.Size = New System.Drawing.Size(82, 17)
        Me.radFlavorChocolate.TabIndex = 8
        Me.radFlavorChocolate.Text = "Schokolade"
        Me.radFlavorChocolate.UseVisualStyleBackColor = True
        '
        'radFlavorSpinach
        '
        Me.radFlavorSpinach.AutoSize = True
        Me.radFlavorSpinach.Location = New System.Drawing.Point(15, 101)
        Me.radFlavorSpinach.Name = "radFlavorSpinach"
        Me.radFlavorSpinach.Size = New System.Drawing.Size(55, 17)
        Me.radFlavorSpinach.TabIndex = 7
        Me.radFlavorSpinach.Text = "Spinat"
        Me.radFlavorSpinach.UseVisualStyleBackColor = True
        '
        'radFlavorRaspberry
        '
        Me.radFlavorRaspberry.AutoSize = True
        Me.radFlavorRaspberry.Location = New System.Drawing.Point(15, 78)
        Me.radFlavorRaspberry.Name = "radFlavorRaspberry"
        Me.radFlavorRaspberry.Size = New System.Drawing.Size(70, 17)
        Me.radFlavorRaspberry.TabIndex = 6
        Me.radFlavorRaspberry.Text = "Himbeere"
        Me.radFlavorRaspberry.UseVisualStyleBackColor = True
        '
        'radFlavorVanilla
        '
        Me.radFlavorVanilla.AutoSize = True
        Me.radFlavorVanilla.Location = New System.Drawing.Point(15, 32)
        Me.radFlavorVanilla.Name = "radFlavorVanilla"
        Me.radFlavorVanilla.Size = New System.Drawing.Size(56, 17)
        Me.radFlavorVanilla.TabIndex = 5
        Me.radFlavorVanilla.Text = "Vanille"
        Me.radFlavorVanilla.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(490, 618)
        Me.Controls.Add(Me.pnlGroupFlavor)
        Me.Controls.Add(Me.picIceOutput)
        Me.Controls.Add(Me.txtSelection)
        Me.Controls.Add(Me.lblBadTaste)
        Me.Controls.Add(Me.btnGiveMeMyIce)
        Me.Controls.Add(Me.trkBarSize)
        Me.Controls.Add(Me.lblHiddenField)
        Me.Controls.Add(Me.lblDragAreaCoinInput)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "Form1"
        CType(Me.trkBarSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picIceOutput, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGroupFlavor.ResumeLayout(False)
        Me.pnlGroupFlavor.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblDragAreaCoinInput As System.Windows.Forms.Label
    Friend WithEvents lblHiddenField As System.Windows.Forms.Label
    Friend WithEvents trkBarSize As System.Windows.Forms.TrackBar
    Friend WithEvents lblBadTaste As System.Windows.Forms.Label
    Friend WithEvents txtSelection As System.Windows.Forms.TextBox
    Friend WithEvents picIceOutput As System.Windows.Forms.PictureBox
    Friend WithEvents btnGiveMeMyIce As System.Windows.Forms.Button
    Friend WithEvents pnlGroupFlavor As System.Windows.Forms.Panel
    Friend WithEvents radFlavorVanillaExtra As System.Windows.Forms.RadioButton
    Friend WithEvents radFlavorChocolate As System.Windows.Forms.RadioButton
    Friend WithEvents radFlavorSpinach As System.Windows.Forms.RadioButton
    Friend WithEvents radFlavorRaspberry As System.Windows.Forms.RadioButton
    Friend WithEvents radFlavorVanilla As System.Windows.Forms.RadioButton

End Class
