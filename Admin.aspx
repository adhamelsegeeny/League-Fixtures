<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Sports.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>Admin</title>
    <meta name="viewport" content="initial-scale = 1.0, maximum-scale = 1.0, user-scalable = no, width = device-width">

    <!--[if lt IE 9]><script src="https://html5shiv.googlecode.com/svn/trunk/html5.js"></script><![endif]-->
    <link rel="stylesheet" href="style.css" media="screen">
    <!--[if lte IE 7]><link rel="stylesheet" href="style.ie7.css" media="screen" /><![endif]-->
    <link rel="stylesheet" href="style.responsive.css" media="all">

    <style>.art-content .art-postcontent-0 .layout-item-0 { color: #B2B2B2; background: #5A9F46; padding: 0px;  }
.art-content .art-postcontent-0 .layout-item-1 { color: #B2B2B2; background: #4C84A9; padding: 0px;  }
.art-content .art-postcontent-0 .layout-item-2 { color: #B2B2B2; background: #3B6C91; padding: 0px;  }
.art-content .art-postcontent-0 .layout-item-3 { padding: 15px;  }
.art-content .art-postcontent-0 .layout-item-4 { color: #B2B2B2; background: #1C3F5A; padding: 15px;  }
.ie7 .art-post .art-layout-cell {border:none !important; padding:0 !important; }
.ie6 .art-post .art-layout-cell {border:none !important; padding:0 !important; }

</style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="art-main">
<header class="art-header">


    <div class="art-shapes">

            </div>
<h1 class="art-headline" data-left="6.85%">
    <a href="#">Champions League</a>
</h1>
<h2 class="art-slogan" data-left="11.11%">The Stadium Is Your Home</h2>

                    
</header>
<div class="art-sheet clearfix">
            <div class="art-layout-wrapper">
                <div class="art-content-layout">
                    <div class="art-content-layout-row">
                        <div class="art-layout-cell art-content"><article class="art-post art-article">
                                
                                                
                <div class="art-postcontent art-postcontent-0 clearfix"><div class="art-content-layout">
    <div class="art-content-layout-row">
    <div class="art-layout-cell layout-item-0" style="width: 32%" >
        <h4>Add/Delete CLub</h4>
         <img width="310" height="197" alt="" class="art-lightbox" src="images/sportsclub.jpg">
    </div><div class="art-layout-cell layout-item-1" style="width: 33%" >
        <h4>Add/Delete Stadium</h4>
         <img width="306" height="196" alt="" class="art-lightbox" src="images/stad.png">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        </div>
        <div class="art-layout-cell layout-item-2" style="width: 34%" >
        <h4>Block Fan</h4>
         <img width="296" height="198" alt="" class="art-lightbox" src="images/block.png">&nbsp; &nbsp; &nbsp;
    </div>
    </div>
</div>
<div class="art-content-layout" >
    <div class="art-content-layout-row" >
    <div class="art-layout-cell layout-item-3" style="width: 32%" >
        <p style="font-style:italic; height:270px">
           Add a club by entering 
            it's name 
            <br />and location
            <br />OR delete a club
            using it's name.
            <br />
            <br />
            <asp:Button ID="check" runat="server" Text="Click to toggle" Onclick="check_CheckedChanged"/>
            <br />
            <br />
            <asp:TextBox ID="club_name" runat="server" CssClass="art-article" Height="12px" Width="170px"></asp:TextBox> Name
            <br />
            <br />
            <asp:TextBox ID="location" runat="server" CssClass="art-article" Height="12px" Width="170px" ></asp:TextBox> Location
            <br />
        <br />
            <br />
            <br />
            <br />
            <asp:Button ID="addc" runat="server" CssClass="art-button" Text="Add Club" onClick="addClub" Height="30px" Width="130px"/>
            <br />
            </p>
       

        
    </div><div class="art-layout-cell layout-item-4" style="width: 33%" >
        <p style="font-style:italic">
           Add a stadium by entering 
            it's name,
            <br />location and capacity
            <br />OR delete a stadium
            using it's name.
            <br />
            <br />
            <asp:Button ID="toggle" runat="server" Text="Click to toggle" Onclick="toggle_Click"/>
            <br />
            <br />
            <asp:TextBox ID="stadium_name" runat="server" CssClass="art-article" Height="12px" Width="170px"></asp:TextBox> Name
            <br />
            <br />
            <asp:TextBox ID="stad_location" runat="server" CssClass="art-article" Height="12px" Width="170px" ></asp:TextBox> Location
            <br />
            <br />
            <asp:TextBox ID="cap" runat="server" CssClass="art-article" Height="12px" Width="170px" ></asp:TextBox> Capacity
            <br />
            <br />
            <asp:Button ID="adds" runat="server" CssClass="art-button" Text="Add Stadium" onClick="adds_Click" Height="30px" Width="130px"/>
            </p>
    </div><div class="art-layout-cell layout-item-3" style="width: 34%; top: 0px; left: 0px;" >
        <p style="font-style:italic">
            Block a fan by entering <br />
            their National ID number.
            <br />
            <br />
            <br />
            <asp:TextBox ID="nat_id" runat="server" CssClass="art-article" Height="12px" Width="104px"/>
            &nbsp; National ID<br />
            <br />
            <br />
            <asp:Button ID="block" runat="server" CssClass="art-button" Text="Block Fan" OnClick="block_Click" />
            <br />
            <br />
            <asp:Button ID="unblock" runat="server" CssClass="art-button" Text="Unblock Fan" OnClick="unblock_Click" />
            </p>
    </div>
    </div>
</div>
<div class="art-content-layout">

    <div class="art-content-layout-row">
   
    </div>

</div>
</div>
                                
                </article>

                        </div>
                    </div>
                </div>
            </div>
    </div>
<footer class="art-footer">
  <div class="art-footer-inner">
<div class="art-content-layout-wrapper layout-item-0">
<div class="art-content-layout layout-item-1">
    <div class="art-content-layout-row">
    <div class="art-layout-cell layout-item-2" style="width: 50%">
        <p>Copyright © 2022-2023. All Rights Reserved.</p>
    </div><div class="art-layout-cell layout-item-2" style="width: 50%">
        <p style="text-align: right;"><a href="#">Privacy Policy</a>&nbsp;&nbsp;&nbsp;&nbsp; <a href="#">Terms Of Use</a>&nbsp;&nbsp;&nbsp;&nbsp; <a href="#">About</a></p>
    </div>
    </div>
</div>
</div>

    <p class="art-page-footer">
        <span id="art-footnote-links">Web Template</a> created by segeeny.</span>
    </p>
  </div>
</footer>

</div>
    </form>
</body>
</html>
