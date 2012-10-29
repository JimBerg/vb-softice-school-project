Imports System.Text.RegularExpressions

Public Class Form1
    '------------------------------------------------------------
    ' declare some evil globals for convenience
    ' it's bad practice and style for sure...
    ' but in the current case we'll have to fear no side effects
    ' ...and it will work
    '------------------------------------------------------------
    Private coinCollection(5) As Coin
    Private slotOpen As Boolean = False 'enable coin input after selection was made
    Private paid As Double = 0
    Private creditValue As Integer = 0
    Private globalPrize As Double = 0 'I've added it afterwards... to make life easier
    Private checkedFlavor As Boolean = False 'no pre selected flavor only preselected standard size
    Private hiddenPic As String = ""

    Private tempPath As String = IO.Directory.GetParent(Application.StartupPath).ToString
    Private picFolder As String = IO.Directory.GetParent(tempPath).ToString


    '------------------------------------------------------------
    ' declare structure Coin as own datatype to combine
    ' - (int) id // to identify
    ' - (int) value // we save whole coins, no partials
    ' - (string) name // redundant, but for easier identification
    ' - (obj PictureBox) container // the related elem on gui
    '-------------------------------------------------------------
    Private Structure Coin
        Dim id As Integer
        Dim value As Integer
        Dim name As String
        Dim container As PictureBox
    End Structure


    '------------------------------------------------------------
    ' "construct" the coinCollection as array
    ' with random values and passed dimension
    ' - @param (int) amount
    ' - @return (array typeof Coin) coinCollection()
    '------------------------------------------------------------
    Private Sub createInitialCredit(ByVal amount As Integer)
        Dim picPath As String
        Randomize() 'initialize randomizer

        For i As Integer = 0 To amount 'create 5 elems of type Coin
            coinCollection(i).id = i 'unique ids
            coinCollection(i).name = "picCoin" & CStr(i)
            coinCollection(i).value = CInt(Int((4 * Rnd()) + 1)) 'create random value at first we won't care if they are real coins

            Try
                picPath = picFolder & "\images\coin_" & coinCollection(i).value & ".png" '

                coinCollection(i).container = New PictureBox()
                coinCollection(i).container.Name = "picCoin" & CStr(i)
                coinCollection(i).container.Image = Image.FromFile(picPath)
                coinCollection(i).container.Size = New Size(60, 60)
                coinCollection(i).container.SizeMode = PictureBoxSizeMode.StretchImage
                coinCollection(i).container.Location = New Point((i + 1) * 75, 520)
                coinCollection(i).container.BackColor = Color.Transparent

                AddHandler coinCollection(i).container.MouseMove, AddressOf OnDoDragPic 'add eventhandler
                Me.Controls.Add(coinCollection(i).container) 'add picbox to form
            Catch ex As Exception
                MsgBox("Leider kannst du dir kein Eis leisten und musst diese App verlassen")
                Exit Sub
            End Try

        Next
    End Sub


    '------------------------------------------------------------
    ' helper "function" (sub in this case) to replace textbox values 
    ' mostly because I wanted to figure out how regExes in VB work
    ' I know those here are not very clever nor flexible, but time is running...
    ' @param (int) replaceStringVal -> where (1: Sorte, 2: Groesse, 3: Preis)
    ' @param (string) replaceValue 
    '------------------------------------------------------------
    Private Sub replaceTextBoxValue(ByVal replaceStringVal, ByVal replaceValue)
        Dim pattern As String = ""
        Dim replacement As String = replaceValue

        Select Case replaceStringVal
            Case 0
                pattern = "STATUS\s{0,1}:\s*\w*\s*\-*\s*\w*\s*.*\r\n"
            Case 1
                pattern = "Sorte\s{0,1}:\s*\w*\s*\-*\w*\s*\w*\r\n"
            Case 2
                pattern = "Grösse\s{0,1}:\s*\w*\-*\w*\s*\r\n"
            Case 3
                pattern = "Preis\s{0,1}:?\s*\w*\.{0,1}\s*\d*\.{0,1}\d*\w*-{0,3}"
            Case 4
                pattern = "gezahlt\s{0,1}:?\s*\w*\.{0,1}\s*\d*\.{0,1}\d*\w*-{0,3}"
        End Select

        Dim regex As New Regex(pattern)
        Dim match As Match = regex.Match(txtSelection.Text)

        If match.Success Then
            Dim result As String = regex.Replace(txtSelection.Text, replacement)
            txtSelection.Text = result
        End If
    End Sub


    '--------------------------------------------------------
    ' helper to get value of all coins to calculate what's left
    ' pass -1 initially to get start credit
    '--------------------------------------------------------
    Private Sub getCreditValue(ByVal coinValue As Integer)
        If coinValue = -1 Then
            For i = 0 To 4
                creditValue += coinCollection(i).value
            Next
        Else
            creditValue -= coinValue
        End If
    End Sub


    '------------------------------------------------------------
    ' calculate prize based on size & flavor
    ' - calculation is done on flavor or size change
    ' - replace text strings on every change, that is made
    '------------------------------------------------------------
    Private Sub calculatePrize()
        Dim prize As Double = 0
        Dim flavorBasePrice As Double 'Base Price
        Dim size As Double
        Dim sizeNames(5) As String 'we create 6 elems, but leave the first one empty, because we only need five, and VB's arrays are kind of strange in handling
        sizeNames = {"", "Diät", "Klein", "Standard", "Gross", "Bärenhunger"}

        For Each control As Control In Me.Controls
            If control.GetType Is GetType(Panel) Then
                Dim thisGroup As Panel = control
                For Each radBtnControl As Control In thisGroup.Controls
                    If radBtnControl.GetType Is GetType(RadioButton) Then
                        Dim thisRadioBtn As New RadioButton
                        thisRadioBtn = radBtnControl

                        If slotOpen = False Then
                            If thisRadioBtn.Checked = True Then
                                Select Case thisRadioBtn.Name
                                    Case "radFlavorVanilla"
                                        flavorBasePrice = 1.0
                                        replaceTextBoxValue(1, "Sorte: Vanille" & vbCrLf)
                                        hiddenPic = "vanilla"
                                    Case "radFlavorVanillaExtra"
                                        flavorBasePrice = 1.8
                                        replaceTextBoxValue(1, "Sorte: Vanille mit Streusel" & vbCrLf)
                                        hiddenPic = "vanillawithbugs"
                                    Case "radFlavorChocolate"
                                        flavorBasePrice = 1.6
                                        replaceTextBoxValue(1, "Sorte: Schokolade" & vbCrLf)
                                        hiddenPic = "chocolate"
                                    Case "radFlavorRaspberry"
                                        flavorBasePrice = 1.2
                                        replaceTextBoxValue(1, "Sorte: Himbeer" & vbCrLf)
                                        hiddenPic = "raspberry"
                                    Case "radFlavorSpinach"
                                        flavorBasePrice = 6.66 'sorry but that's really evil taste
                                        replaceTextBoxValue(1, "Sorte: Spinat" & vbCrLf)
                                        hiddenPic = "spinach"
                                End Select
                            End If
                        ElseIf slotOpen = True Then
                            radBtnControl.Enabled = False 'disable controls after selection is made
                        End If
                    End If
                Next
            End If
        Next

        If slotOpen = False Then
            If trkBarSize.Value >= 3 Then
                size = CDbl(trkBarSize.Value) - 1 + (1 / 3) * CDbl(trkBarSize.Value)
            ElseIf trkBarSize.Value = 2 Then
                size = CDbl(trkBarSize.Value) - 1 - (1 / 3) * CDbl(trkBarSize.Value)
            ElseIf trkBarSize.Value = 1 Then 'mini diet portions always cost extra...
                size = CDbl(trkBarSize.Value) + 2
            End If
            prize = flavorBasePrice + size * (flavorBasePrice)
            replaceTextBoxValue(2, "Grösse: " & CStr(sizeNames(CInt(trkBarSize.Value))) & vbCrLf)
            replaceTextBoxValue(3, "Preis: " & FormatCurrency(prize))
            globalPrize = prize
        ElseIf slotOpen = True Then
            trkBarSize.Enabled = False 'disable controls after selection is made
        End If
 
    End Sub



    '------------------------------------------------------------
    ' EVENT HANDLING
    '------------------------------------------------------------

    '--------------------------------------------------------
    ' drag n drop handler
    ' init drag event -> capture mouseDown on coin.cointainer
    ' @param sender - coin.container == instance of PictureBox
    ' @param e Mouse Event
    '--------------------------------------------------------
    Private Sub OnDoDragPic(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim thisPic As PictureBox 'current pic, that calls the method
        Dim searchString As String 'used as helper to identify the current elem

        thisPic = sender
        searchString = thisPic.Name

        If Not thisPic.Image Is Nothing Then 'check if there's an image
            thisPic.DoDragDrop(thisPic.Image, DragDropEffects.Move)

            ' for lack of experience with objects, eventHandling and other VB stuff
            ' I'll have to do it the dirty way...
            ' loop over all coins to capture the - (fortunately we've got only five max)
            For Each coins As Coin In coinCollection
                If coins.name = searchString Then 'and now we've got our elem and set it's id & value to a hidden field
                    lblHiddenField.Text = coins.id
                End If
            Next
        End If
    End Sub


    '--------------------------------------------------------
    ' check for drag enter event on coin slot
    '--------------------------------------------------------
    Private Sub lblDragAreaCoinInput_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lblDragAreaCoinInput.DragEnter
        e.Effect = e.AllowedEffect
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub


    '--------------------------------------------------------
    ' after element was dropped... 
    ' recalculate what was paid, what has to be payed, return cash
    ' remove coins
    ' set states according to those params
    ' set ice picture in case we've fullfilled the conditions
    '--------------------------------------------------------
    Private Sub lblDragAreaCoinInput_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lblDragAreaCoinInput.DragDrop
        Dim returnMoney As Double
        Dim icePic As String
        Dim flavor As String
        Dim size As String

        If slotOpen = True Then
            paid += coinCollection(CDbl(lblHiddenField.Text)).value
            getCreditValue(coinCollection(CDbl(lblHiddenField.Text)).value)

            If paid < globalPrize Then
                replaceTextBoxValue(4, "gezahlt: " & FormatCurrency(paid))
                'not removing elem from array, because we will need the indices and there's actually no need to do it
                coinCollection(CInt(lblHiddenField.Text)).container.Dispose() 'clear out the picture
                coinCollection(CInt(lblHiddenField.Text)) = Nothing 'spend your money, so nothing's left :)
            ElseIf paid >= globalPrize Then
                slotOpen = False 'disable coin input
                lblDragAreaCoinInput.AllowDrop = False
                returnMoney = paid - globalPrize

                If (returnMoney > 0) Then
                    txtSelection.Text = "STATUS: Du bekommst dein Eis!" & vbCrLf & "Und würde dieser Automat Rückgeld geben noch: " & CStr(FormatCurrency(returnMoney)) & " zurück."
                    flavor = hiddenPic 'at this state the values of flavor n size are given and fixed, so we can take them
                    size = CStr(trkBarSize.Value)

                    Try
                        icePic = picFolder & "\images\" & flavor & "_" & size & ".png" 'set image
                        picIceOutput.Image.Dispose()
                        picIceOutput.Image = Image.FromFile(icePic)
                        Me.ttpHelper.SetToolTip(Me.picIceOutput, "Nimm das Eis! No dragging - just clicking.") 'set tooltip as helper 
                        AddHandler picIceOutput.Click, AddressOf takeIceAndRestart
                    Catch ex As Exception
                        MsgBox("Huch, kein Eis mehr da - komm im Sommer wieder")
                        Exit Sub
                    End Try

                ElseIf returnMoney = 0 Then
                    coinCollection(CInt(lblHiddenField.Text)).container.Dispose() 'in this case we have to remove the coin too
                    coinCollection(CInt(lblHiddenField.Text)) = Nothing

                    txtSelection.Text = "STATUS: Du bekommst dein Eis!"
                    flavor = hiddenPic 'at this state the values of flavor n size are given and fixed, so we can take them
                    size = CStr(trkBarSize.Value)
                    Try
                        icePic = picFolder & "\images\" & flavor & "_" & size & ".png" 'set image
                        picIceOutput.Image.Dispose()
                        picIceOutput.Image = Image.FromFile(icePic)
                        Me.ttpHelper.SetToolTip(Me.picIceOutput, "Nimm das Eis! No dragging - just clicking.") 'set tooltip as helper 
                        AddHandler picIceOutput.Click, AddressOf takeIceAndRestart
                    Catch ex As Exception
                        MsgBox("Huch, kein Eis mehr da - komm im Sommer wieder")
                        Exit Sub
                    End Try
                End If

            End If

        ElseIf slotOpen = False Then
            replaceTextBoxValue(0, "STATUS: Erst wählen und bestätigen." & vbCrLf)
        End If
    End Sub

    '------------------------------------------------------------
    ' get the size of the ice :)
    ' recalculate prize on trackbar-value change
    '------------------------------------------------------------
    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trkBarSize.Scroll
        calculatePrize()
    End Sub


    '------------------------------------------------------------
    ' recalculate prize on every checkbox change
    ' combine eventhandling for each radBtn to one handler
    '------------------------------------------------------------
    Private Sub pnlGroupFlavor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
        radFlavorRaspberry.CheckedChanged, _
        radFlavorChocolate.CheckedChanged, _
        radFlavorVanilla.CheckedChanged, _
        radFlavorVanillaExtra.CheckedChanged, _
        radFlavorSpinach.CheckedChanged

        checkedFlavor = True 'any selection was made, so we can assume the customer made it on purpose
        calculatePrize()
    End Sub


    '------------------------------------------------------------
    ' on click, confirm your selection
    ' - click to enables payment
    ' - check, if we've got enough money to pay our choosen ice
    '------------------------------------------------------------
    Private Sub btnGiveMeMyIce_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGiveMeMyIce.Click
        If checkedFlavor = False Then
            replaceTextBoxValue(0, "STATUS: Bitte erst wählen." & vbCrLf)
        Else
            If creditValue < globalPrize Then
                MsgBox("GAME OVER! Du hast nicht genügend Geld um Eis zu essen. Restart the App!")
                If MsgBoxResult.Ok = 1 Then
                    Application.Restart()
                End If
                Exit Sub
            Else
                replaceTextBoxValue(0, "STATUS: Gewählt. Bitte zahlen." & vbCrLf)
                slotOpen = True
                lblDragAreaCoinInput.Image.Dispose()
                lblDragAreaCoinInput.Image = Nothing
                lblDragAreaCoinInput.BackColor = Color.Transparent
                btnGiveMeMyIce.Enabled = False
                btnGiveMeMyIce.Image = Image.FromFile(picFolder & "\images\btnStartInactive.jpg")
                calculatePrize() 'set radiobtns n trackbar to disabled
            End If
        End If

    End Sub


    '------------------------------------------------------------
    ' close application
    '------------------------------------------------------------
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub


    '------------------------------------------------------------
    ' close from msgbox after receiving our ice
    '------------------------------------------------------------
    Private Sub takeIceAndRestart(ByVal sender As Object, ByVal e As EventArgs)
        MsgBox("Das war's", MsgBoxStyle.OkOnly)
        If MsgBoxResult.Ok = 1 Then
            Me.Close()
        End If
    End Sub


    '------------------------------------------------------------
    ' the init method - to get and set all we need on page load
    ' in this case: our randomized start credit and we want to know
    ' how much it is all together...
    '------------------------------------------------------------
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim amount As Integer = 4 'we want 5 coins
        createInitialCredit(amount) 'now let's call the function to get some pocket money :)
        getCreditValue(-1) 'get initial credit to check which ice we can afford

        Me.ttpHelper.SetToolTip(Me.btnGiveMeMyIce, "Bitte hier die Auswahl besätigen!") 'set tooltip as helper      
    End Sub

End Class
