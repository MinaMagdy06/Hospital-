namespace HospitalManagementSystem.Forms;
partial class DoctorEditForm
{
    private TextBox txtFullName,txtSpecialization,txtPhone,txtEmail;private ComboBox cmbDepartment;
    private void InitializeDerived(){Text="Doctor";ClientSize=new Size(560,360);var l=new TableLayoutPanel{Dock=DockStyle.Top,Height=230,ColumnCount=2,RowCount=5};l.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute,140));l.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,100));txtFullName=new TextBox{Name="txtFullName",Dock=DockStyle.Fill};txtSpecialization=new TextBox{Name="txtSpecialization",Dock=DockStyle.Fill};txtPhone=new TextBox{Name="txtPhone",Dock=DockStyle.Fill};txtEmail=new TextBox{Name="txtEmail",Dock=DockStyle.Fill};cmbDepartment=new ComboBox{Name="cmbDepartment",DropDownStyle=ComboBoxStyle.DropDownList,Dock=DockStyle.Fill};Add(l,"Full name",txtFullName,0);Add(l,"Specialization",txtSpecialization,1);Add(l,"Phone",txtPhone,2);Add(l,"Email",txtEmail,3);Add(l,"Department",cmbDepartment,4);FieldsPanel.Controls.Add(l);}
    private static void Add(TableLayoutPanel l,string text,Control c,int row){l.Controls.Add(new Label{Text=text,AutoSize=true},0,row);l.Controls.Add(c,1,row);}
}
