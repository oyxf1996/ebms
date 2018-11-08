<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Search.ascx.cs" Inherits="oyxf.Portal.UserControl.Search" %>
<div class="topic">搜索&nbsp;&nbsp;&nbsp;Search</div>
<div class="SearchBar">
    <form method="get" action="/Search/index.asp">
        <input type="text" name="q" id="search-text" size="15" onblur="if(this.value=='') this.value='请输入关键词';" onfocus="if(this.value=='请输入关键词') this.value='';" value="请输入关键词"><input type="submit" id="search-submit" value="搜索">
    </form>
</div>
