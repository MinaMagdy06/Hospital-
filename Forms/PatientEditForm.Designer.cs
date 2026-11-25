namespace HospitalManagementSystem.Forms;
partial class PatientEditForm
{
    private TextBox txtFullName,txtPhone,txtEmail,txtAddress;private DateTimePicker dtpDateOfBirth;private ComboBox cmbGender;
    private void InitializeDerived(){Text="Patient";ClientSize=new Size(560,430);var l=new TableLayoutPanel{Dock=DockStyle.Top,Height=300,ColumnCount=2,RowCount=6};l.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute,140));l.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,100));txtFullName=new TextBox{Name="txtFullName",Dock=DockStyle.Fill};dtpDateOfBirth=new DateTimePicker{Name="dtpDateOfBirth",Dock=DockStyle.Fill,Format=DateTimePickerFormat.Short};cmbGender=new ComboBox{Name="cmbGender",Dock=DockStyle.Fill,DropDownStyle=ComboBoxStyle.DropDownList};cmbGender.Items.AddRange(new object[]{"Male","Female"});txtPhone=new TextBox{Name="txtPhone",Dock=DockStyle.Fill};txtEmail=new TextBox{Name="txtEmail",Dock=DockStyle.Fill};txtAddress=new TextBox{Name="txtAddress",Dock=DockStyle.Fill,Multiline=true};Add(l,"Full name",txtFullName,0);Add(l,"Date of birth",dtpDateOfBirth,1);Add(l,"Gender",cmbGender,2);Add(l,"Phone",txtPhone,3);Add(l,"Email",txtEmail,4);Add(l,"Address",txtAddress,5);FieldsPanel.Controls.Add(l);}
    private static void Add(TableLayoutPanel l,string text,Control c,int row){l.Controls.Add(new Label{Text=text,AutoSize=true},0,row);l.Controls.Add(c,1,row);}
}
