<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="oyxf.OPPortal.Category.List" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="oyxf.Common" %>
<%@ Import Namespace="oyxf.Model.Enum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .list {
            margin: 0 auto;
            width: 600px;
        }

            .list #gvCategory th, .list #gvCategory td {
                text-align: center;
            }

        #btnAdd {
            margin: 10px 0px 10px 0px;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="right" runat="server">
    <div class="list">
        <asp:Label ID="lblCategoryId" runat="server" Text="分类编号："></asp:Label>
    <asp:TextBox ID="txtCategoryId" runat="server"></asp:TextBox>
    &nbsp;
    <asp:Label ID="lblCategoryName" runat="server" Text="分类名称："></asp:Label>
    <asp:TextBox ID="txtCategoryName" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblType" runat="server" Text="类型："></asp:Label>
    <asp:DropDownList ID="ddlType" runat="server">
        <asp:ListItem Value="">未选择</asp:ListItem>
        <asp:ListItem Value="1">链接</asp:ListItem>
        <asp:ListItem Value="2">内容页</asp:ListItem>
        <asp:ListItem Value="3">新闻列表</asp:ListItem>
        <asp:ListItem Value="4">产品列表</asp:ListItem>
    </asp:DropDownList>
    &nbsp;
    <asp:Label ID="lblStatus" runat="server" Text="状态："></asp:Label>
    <asp:DropDownList ID="ddlStatus" runat="server">
       <asp:ListItem Value="">未选择</asp:ListItem>
       <asp:ListItem Value="0">不显示</asp:ListItem>
       <asp:ListItem Value="1">显示</asp:ListItem>
    </asp:DropDownList>
    <asp:Label ID="lblFatherCategoryName" runat="server" Text="父分类名称："></asp:Label>
    <asp:TextBox ID="txtFatherCategoryName" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="btnSerach" runat="server" Text="搜索" />
    <asp:Button ID="btnClear" runat="server" Text="重置" />
    <br />

        <asp:Button ID="btnAdd" runat="server" Text="添加分类" OnClick="btnAdd_Click" />
        <asp:GridView ID="gvCategory" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="gvCategory_RowDataBound" OnRowCommand="gvCategory_RowCommand">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="CategoryId" HeaderText="分类编号">
                    <HeaderStyle Width="80px" />
                </asp:BoundField>
                <asp:BoundField DataField="Name" HeaderText="分类名称">
                    <HeaderStyle Width="100px" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="类型">
                    <ItemTemplate>
                        <asp:Label ID="lblTypeName" runat="server" Text='<%#Eval("Type") %>' Visible="false"></asp:Label>
                        <asp:Label ID="lblType" runat="server" Text='<%#EnumHelper.GetDescription<CategoryType>(Convert.ToInt64(Eval("Type")))%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="100px" />
                </asp:TemplateField>
                <asp:BoundField DataField="ParentCategoryName" HeaderText="父分类名称">
                    <HeaderStyle Width="100px" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="状态">
                    <ItemTemplate>
                        <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status")%>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Width="80px" />
                </asp:TemplateField>
                <asp:BoundField DataField="SortIndex" HeaderText="排序">
                    <HeaderStyle Width="50px" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="内容操作">
                    <ItemTemplate>
                        <asp:HyperLink ID="lnkEditContent" runat="server" NavigateUrl='<%#"/Category/EditContent.aspx?id="+Eval("CategoryId").ToString() %>' Visible="false">编辑内容</asp:HyperLink>
                    </ItemTemplate>
                    <HeaderStyle Width="80px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <!--注意拼接navigatorurl时，外面要用单引号-->
                        <asp:HyperLink ID="lnkEdit" runat="server" NavigateUrl='<%#"/Category/Edit.aspx?id="+Eval("CategoryId").ToString() %>'>修改</asp:HyperLink>
                        <asp:LinkButton ID="lbtnDel" runat="server" CommandName="del" CommandArgument='<%#Eval("CategoryId")%>' OnClientClick="return confirm('确认要删除么？')">删除</asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle Width="100px" />
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>

        <webdiyer:AspNetPager ID="anpCategory" runat="server" PageSize="10" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" OnPageChanging="anpCategory_PageChanging"></webdiyer:AspNetPager>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
