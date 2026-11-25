namespace HospitalManagementSystem.Forms;
partial class DepartmentEditForm
{
    private TextBox txtName,txtDescription;
    private void InitializeDerived(){Text="Department";ClientSize=new Size(520,300);var layout=new TableLayoutPanel{Dock=DockStyle.Top,Height=150,ColumnCount=2,RowCount=2};layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute,120));layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,100));txtName=new TextBox{Name="txtName",Dock=DockStyle.Fill};txtDescription=new TextBox{Name="txtDescription",Multiline=true,Dock=DockStyle.Fill};layout.Controls.Add(new Label{Text="Name",AutoSize=true},0,0);layout.Controls.Add(txtName,1,0);layout.Controls.Add(new Label{Text="Description",AutoSize=true},0,1);layout.Controls.Add(txtDescription,1,1);FieldsPanel.Controls.Add(layout);}
}
