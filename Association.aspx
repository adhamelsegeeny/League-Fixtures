<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Association.aspx.cs" Inherits="Sports.Association" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>Sports Manager</title>
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
        <h4>Add/Delete Match</h4>
         <img width="270" height="197" alt="" src="images/match.jpg" />
    </div><div class="art-layout-cell layout-item-1" style="width: 37%" >
        <h4>View Matches</h4>
         <img width="306" height="196" alt="" class="art-lightbox" src="images/match2.jpg" style="margin:0px 0px 0px 26px" />&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        </div>
        <div class="art-layout-cell layout-item-2" style="width: 31%" >
        <h4>Clubs Never Matched</h4>
         <img style="max-width:100%; max-height:100%" alt="" src="images/match3.jpg" />&nbsp; &nbsp; &nbsp;
    </div>
    </div>
</div>
<div class="art-content-layout" >
    <div class="art-content-layout-row" >
    <div class="art-layout-cell layout-item-3" style="width: 32%" >
        <p style="font-style:italic; height:450px">
            <strong>
            Add or delete a Match 
            <br />
            by entering Host and Guest
            <br />names in addition to
            <br />both start and end times
                </strong>
            <br />
            <br />
            <asp:Button ID="check" runat="server" Text="Click to toggle" Onclick="check_Click"/>
            <br />
            <br />
            <asp:TextBox ID="host" runat="server" CssClass="art-article" Height="12px" Width="170px" ></asp:TextBox> Host
            <br />
            <br />
            <asp:TextBox ID="guest" runat="server" CssClass="art-article" Height="12px" Width="170px" ></asp:TextBox> Guest
            <br />
            <br />
            <asp:TextBox ID="start" runat="server" CssClass="art-article" Height="20px" Width="170px" TextMode="DateTimeLocal"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="end" runat="server" CssClass="art-article" Height="20px" Width="170px" TextMode="DateTimeLocal"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="addm" runat="server" CssClass="art-button" Text="Add Match" onClick="addm_Click" Height="30px" Width="130px"/>
            <br />
            </p>
       

        
    </div><div class="art-layout-cell layout-item-4" style="width: 37%" >
        <p style="font-style:italic">
            <strong>
           Toggle between viewing upcoming 
            <br />
            matches and already played matches 
            <br />
            by clicking on the button below
                </strong>
            <br />
            <br />
            <asp:Button ID="matches" runat="server" CssClass="art-button" Height="30px" Width="190px" OnClick="matches_Click" Text="View Already Played" />
            <br />
            <br />
           <asp:Label ID="label" runat="server" Width="300px" Height="300px"></asp:Label>




    </div><div class="art-layout-cell layout-item-3" style="width: 31%; top: 0px; left: 0px;" >
        <p style="font-style:italic">
           <asp:Label ID="never" runat="server"></asp:Label>
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
