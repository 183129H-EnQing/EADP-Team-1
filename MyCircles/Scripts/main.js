var notificationUri = '/api/notifications';
var followUri = '/api/follows';
var postUri = '/api/posts';
var userUri = '/api/users';
var circlesUri = '/api/circles';
var signupeventdetailsUri = '/api/signupeventdetails';
var showNotifications = true;


function disableAsyncButton(btn, message = "Loading...") {
    btn.value = message;
    btn.disabled = true;
}

function parseJsonDate(jsonDateString) {
    return new Date(jsonDateString.match(/\d+/)[0] * 1);
};

const getCurrentCity = (lat = null, lng = null) => {
    return new Promise((resolve, reject) => {
        try {
            var currentCity = null;
            var latlng = new google.maps.LatLng(lat, lng);

            new google.maps.Geocoder().geocode({ 'latLng': latlng }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    if (results[1]) {
                        let c, lc, component;
                        for (let r = 0, rl = results.length; r < rl; r += 1) {
                            let result = results[r];
                            if (!currentCity && result.types[0] === 'neighborhood') {
                                for (c = 0, lc = result.address_components.length; c < lc; c += 1) {
                                    component = result.address_components[c];
                                    if (component.types[0] === 'neighborhood') {
                                        resolve(component.long_name);
                                    }
                                }
                            }
                        }
                    }
                }
                else {
                    console.log(status);
                }
            });
        } catch (error) {
            console.log(error);
            reject("Unknown");
        }
    });
}

function addNotificationToasts(notifications) {
    if (notifications.length > 0) {
        for (i = 0; i < notifications.length; i++) {
            let toast =
                '<div class="toast rounded" role="alert" aria-live="assertive" aria-atomic="true" data-delay="100000"><div class="toast-header">' +
                '<img src="/Content/images/MyCirclesIconStatic.png" width="20px" height="20px" alt="MyCircles Logo">&nbsp;' +
                '<strong class="mr-auto"><b>MyCircles</b></strong><small class="text-muted">just now</small><button type="button" class="ml-2 mb-1 close" data-dismiss="toast" aria-label="Close">' +
                '<span aria-hidden="true">&times;</span></button></div><div class="toast-body">' +
                `<div style="font-weight:500;"><span class="${notifications[i].Type}-action">${notifications[i].Action}</span> from ${notifications[i].Source.toLowerCase()}</div>`

            if (notifications[i].AdditionalMessage) {
                toast += `<div class="text-italic">${notifications[i].AdditionalMessage}</div>`;
            }

            toast += `</div>`;

            if (notifications[i].CallToAction) {
                toast +=
                    `<div class="toast-footer text-center" style="padding: 5px;">` +
                    `<form method="post" action="${notifications[i].CallToActionLink}">` +
                    `<button type="submit" style="border: 0; background-color: transparent;"><span class="positive-action">${notifications[i].CallToAction}</span></button></form></div>`
            };

            toast.concat(`</div>`);
            $('.toast-container').append(toast);
            $('.toast').toast('show');
        };
    };
}

function getPostDom(posts) {
    var postHtml = "";

    posts.forEach(function (post) {
        postHtml +=
            "<div class='row justify-content-md-center search-post border-bottom py-3'>" +
            "<div class='col-1'>" +
            `<a href='User.aspx?username=${post.PostUser.Username}' class="text-decoration-none">` +
            `<img class="rounded-circle object-fit" height="50px" width="50px" src="${post.PostUser.ProfileImage}" />` +
            `</a>` +
            `</div>` +
            `<div class="col-9">` +
            `<div class="row">` +
            `<div class="col-12">` +
            `<a href="User.aspx?username=${post.PostUser.Username}" class="text-decoration-none">` +
            `<span class="h5">${post.PostUser.Name}&nbsp;<small class="text-muted">@${post.PostUser.Username}</small></span>` +
            `</a>` +
            `<span class="float-right">${moment(post.DateTime).format('h:mm a')}</span>` +
            `</div>` +
            `</div>` +
            `<span class="display-2" style="font-size:28px">` +
            `${post.Content}    •    <span class="text-primary">${post.CircleId}</span>` +
            `</span><br />`;

        if (post.Image) {
            postHtml += `<img src="${post.Image}" style="max-height: 300px; width: auto;" class="card-image rounded">`;
        }

        if (post.Comments.length) {
            postHtml += `<div class="bg-light rounded p-2 mt-2">`

            post.Comments.forEach(function (comment) {
                postHtml +=
                    `<div class="p-2 border-bottom"><div class="row">` +
                    `<div class="col-1">` +
                    `<a href="User.aspx?username=${comment.CommentUser.Username}" class="text-decoration-none">` +
                    `<img class="rounded-circle object-fit" height="35px" width="35px" src="${comment.CommentUser.ProfileImage}" />` +
                    `</a>` +
                    `</div>` +
                    `<div class="col-11">` +
                    `<div>` +
                    `<a href="User.aspx?username=${comment.CommentUser.Username}" class="text-decoration-none">` +
                    `<span class="h6">${comment.CommentUser.Name}&nbsp;<small class="text-muted">@${comment.CommentUser.Username}</small></span>` +
                    `</a>` +
                    `<span class="float-right" style="font-size: 13px;">${moment(comment.CommentDate).format('h:mm a')}</span>` +
                    `</div>` +
                    `<span class="display-2" style="font-size: 18px">${comment.CommentContent}</span>` +
                    `</div>` +
                    `</div></div>`
            });

            postHtml += `</div>`
        }

        postHtml += `</div></div>`;
    });

    return postHtml
}

function getUserDom(users, currentUserId) {
    var userHtml = `<div class="user-card-columns card-columns search-user" style="column-count: 2;">`;

    users.forEach(function (user) {
        userHtml +=
            `<div class="card border-light-color thick-border shadow-sm">` +
            `<div class="card-body">` +
            `<div class="row">` +
            `<div class="col-md-3 profilepic-container">` +
            `<a href="User.aspx?username=${user.Username}" class="text-decoration-none">` +
            `<img class="rounded-circle object-fit" height="80px" width="80px" src="${user.ProfileImage}" />` +
            `</div>` +
            `<div class="col-md-9 desc-container">` +
            `<span class='m-0 h4'>${user.Name}</span><br />` +
            `<span class='m-0 text-muted'>@${user.Username}</span></a>` +
            `<span class='d-block font-italic py-1 display-${user.Bio != null}'>${user.Bio}</span><br />` +
            `<i class='fa fa-map-marker' aria-hidden='true'></i>&nbsp;` +
            `<span>${user.City}</span>` +
            `</div>` +
            `</div>` +
            `</div>` +
            `<div class="card-footer">` +
            `<div class="row">` +
            `<div class="col-md-12"><button class="btn btn-primary px-4 w-100 btn-follow" type="button" followingId=${user.Id} followerId=${currentUserId}>Follow</button></div>` +
            `</div>` +
            `</div>` +
            `</div>`;
    });

    userHtml += `</div>`

    return userHtml;
}

function ajaxHelper(uri, method, data) {
    return $.ajax({
        type: method,
        url: uri,
        dataType: 'json',
        contentType: 'application/json',
        data: data ? JSON.stringify(data) : null
    }).fail(function (jqXHR, textStatus, errorThrown) {
        console.log(errorThrown);
    });
}

function getUserNotifications(userId) {
    ajaxHelper(`${notificationUri}/${userId}`, 'GET', null).done(function (data) {
        if (showNotifications) {
            addNotificationToasts(data);
        }
    });
}

function addNotification({ Action, Source, UserId, Type = "neutral", AdditionalMessage = null, CallToAction = null, CallToActionLink = null, IsRead = false } = {}) {
    var notification = {
        Action: Action,
        Source: Source,
        UserId: UserId,
        Type: Type,
        AdditionalMessage: AdditionalMessage,
        CallToAction: CallToAction,
        CallToActionLink: CallToActionLink, 
        IsRead: IsRead,
    };

    ajaxHelper(notificationUri, 'POST', notification).done(function (item) {
        console.log(item);
    });
}

function updateFollowButton(followButtons) {
    $(followButtons).each(function (i, btn) {
        var followingId = $(btn).attr('followingId');
        var followerId = $(btn).attr('followerId');

        if (followingId != followerId) {
            ajaxHelper(`${followUri}/GetFollowByUsers/${Number(followerId)}/${Number(followingId)}`, 'GET', null)
            .done(function (followExists) {
                if (followExists) {
                    $(btn).addClass('btn-primary').removeClass('btn-outline-primary');
                    $(btn).html("Following");
                } else {
                    $(btn).addClass('btn-outline-primary').removeClass('btn-primary');
                    $(btn).html("Follow");
                }
            });
        } else {
            $(btn).addClass('d-none');
        }
    });
}
