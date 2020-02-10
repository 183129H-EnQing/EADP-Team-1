<%@ Page Title="Search - MyCircles" Language="C#" MasterPageFile="~/SignedIn.master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="MyCircles.Profile.Search" %>

<asp:Content ID="SearchHead" ContentPlaceHolderID="SignedInHeadPlaceholder" runat="server">
</asp:Content>

<asp:Content ID="SearchContent" ContentPlaceHolderID="SignedInContentPlaceholder" runat="server">
    <div class="rounded container-lg content-container bg-white p-0 shadow-sm mb-6">
        <div class="border-bottom thick-border p-5">
            <div class="input-group shadow-sm">
                <span class="input-group-prepend">
                    <div class="border-right-0 input-group-text bg-transparent"><i class="fa fa-search"></i></div>
                </span>
                <input id="tbSearchQuery" class="shadow-none input-height-lg rounded form-control flexdatalist border-left-0" type="text" placeholder="Search" data-min-length="1" list="postDataList" name="searchQuery" />
            </div>
        </div>
        <div class="border-top thick-border p-5 mb-3">
            <div class="row">
                <div class="col-md-3 border-right">
                    <div class="nav flex-column nav-pills" id="v-pills-tab" role="tablist" aria-orientation="vertical">
                        <a class="nav-link active" id="v-pills-posts-tab" data-toggle="pill" href="#v-pills-posts" role="tab" aria-controls="v-pills-posts" aria-selected="true">Posts</a>
                        <%--<a class="nav-link" id="v-pills-circles-tab" data-toggle="pill" href="#v-pills-circles" role="tab" aria-controls="v-pills-circles" aria-selected="false">Circles</a>--%>
                        <a class="nav-link" id="v-pills-people-tab" data-toggle="pill" href="#v-pills-people" role="tab" aria-controls="v-pills-people" aria-selected="false">People</a>
                    </div>
                </div>
                <div class="col-md-9 border-left">
                    <div class="tab-content" id="v-pills-tabContent">
                        <div class="tab-pane fade show active" id="v-pills-posts" role="tabpanel" aria-labelledby="v-pills-posts-tab">
                            <div id="no-post-message" class="text-center">
                                <span class="h4">
                                    No posts found
                                </span>
                            </div>
                            <%--<div class="row search-post border-bottom py-3">
                                <div class="col-1">
                                    <a href="User.aspx?username=bala12rupesh" class="text-decoration-none">
                                        <img class="rounded-circle object-fit" height="50px" width="50px" src="../Content/images/profile-picture-2.jpg" />
                                    </a>
                                </div>
                                <div class="col-9">
                                    <div class="row">
                                        <div class="col-12">
                                            <a href="User.aspx?username=bala12rupesh" class="text-decoration-none">
                                                <span class="h5">Vignesh
                                                    <small class="text-muted">@bala12rupesh</small>
                                                </span>
                                            </a>
                                            <span class="float-right">Sengkang   •    12:36am</span>
                                        </div>
                                    </div>
                                    <span class="display-2" style="font-size:28px">
                                        Woah this is so cool   •    <span class="text-primary">general</span>
                                    </span><br />
                                    <img src="" style="max-height: 300px; width: auto; border-radius: 8px;" class="card-image">
                                    <div class="bg-light rounded p-2">
                                        <div class="row">
                                            <div class="col-1">
                                                <a href="User.aspx?username=bala12rupesh" class="text-decoration-none">
                                                    <img class="rounded-circle object-fit" height="35px" width="35px" src="../Content/images/profile-picture-2.jpg" />
                                                </a>
                                            </div>
                                            <div class="col-11">
                                                <div>
                                                    <a href="User.aspx?username=bala12rupesh" class="text-decoration-none">
                                                        <span class="h6">Vignesh
                                                            <small class="text-muted">@bala12rupesh</small>
                                                        </span>
                                                    </a>
                                                    <span class="float-right" style="font-size: 13px;">12:36am</span>
                                                </div>
                                                <span class="display-2" style="font-size: 18px">Woah this is so cool
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>--%>
                        </div>
                        <div class="tab-pane fade" id="v-pills-circles" role="tabpanel" aria-labelledby="v-pills-circles-tab">
                            <div id="no-circles-message" class="text-center">
                                <span class="h4">No circles found
                                </span>
                            </div>
                        </div>
                        <div class="tab-pane fade" id="v-pills-people" role="tabpanel" aria-labelledby="v-pills-people-tab">
                            <div id="no-user-message" class="text-center">
                                <span class="h4">No people found
                                </span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <datalist id="postDataList" runat="server" ClientIDMode="Static">
    </datalist>

    <datalist id="circleDataList" runat="server" ClientIDMode="Static">
    </datalist>

    <datalist id="userDataList" runat="server" ClientIDMode="Static">
    </datalist>

    <script>
        $('#v-pills-posts-tab').click(function () {
            $('#tbSearchQuery').attr('list', 'postDataList');
        });

        $('#v-pills-circles-tab').click(function () {
            $('#tbSearchQuery').attr('list', 'circleDataList');
        });

        $('#v-pills-people-tab').click(function () {
            $('#tbSearchQuery').attr('list', 'userDataList');
        });

        $('#tbSearchQuery')
        .bind("propertychange change keyup input", function (event) {
            let searchQuery = $('#tbSearchQuery').val();

            ajaxHelper(`${postUri}/getbyquery/${searchQuery}`, 'GET', null).done(function (data) {
                $('.search-post').remove();

                if (data.length) {
                    if (data[0].IsPost) {
                        var postHtml = getPostDom(data);
                        $('#no-post-message').css("display", "none");
                        $('#v-pills-posts').append(postHtml);
                    } else {
                        $('#no-post-message').css("display", "block");
                    }
                } else {
                    $('#no-post-message').css("display", "block");
                }
            });

            ajaxHelper(`${userUri}/${searchQuery}`, 'GET', null).done(function (data) {
                $('.search-user').remove();

                if (data.length) {
                    if (data[0].IsUser) {
                        var userHtml = getUserDom(data, <%= currentUser.Id %>);
                        $('#no-user-message').css("display", "none");
                        $('#v-pills-people').append(userHtml);
                    } else {
                        $('#no-user-message').css("display", "block");
                    }
                } else {
                    $('#no-user-message').css("display", "block");
                }

                updateFollowButton(".btn-follow")
            });

            ajaxHelper(`${circlesUri}/${searchQuery}`, 'GET', null).done(function (data) {
                $('.search-circles').remove();

                conosle.log(data);

                if (data.length) {
                    if (data[0].IsUser) {
                        $('#no-user-message').css("display", "none");
                    } else {
                        $('#no-user-message').css("display", "block");
                    }
                } else {
                    $('#no-user-message').css("display", "block");
                }
            });
        });
    </script>
</asp:Content>

<asp:Content ID="SearchDeferredScripts" ContentPlaceHolderID="SignedInDeferredScriptsPlaceholder" runat="server">
</asp:Content>
