var notificationUri = '/api/notifications';

function disableAsyncButton(btn, message = "Loading...") {
    btn.value = message;
    btn.disabled = true;
}

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
                toast.concat(`<div class="toast-body">${notifications[i].AdditionalMessage}</div>`);
            }

            toast.concat(`</div>`);

            if (notifications[i].CallToAction) {
                toast.concat(
                    `<div class="toast-footer row" style="padding: 5px;">` +
                    `<form method="post" action="${notifications[i].CallToActionLink}" id="acceptInvitationForm">` +
                    `<button type="submit" style="border: 0; background-color: transparent;"><span class="positive-action">${notifications[i].CallToAction}</span></button></form></div>`
                );
            };

            toast.concat(`</div>`);

            $('.toast-container').append(toast);

            $('.toast').toast('show');
        };
    };
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
        addNotificationToasts(data);
    });
}

function addNotification({ Action, Source, UserId, Type = "positive", AdditionalMessage = null, CallToAction = null, CallToActionLink = null, IsRead = false } = {}) {
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

$('body').on('click', '.close', function () {
    $(this).closest('.toast').toast('hide')
})
