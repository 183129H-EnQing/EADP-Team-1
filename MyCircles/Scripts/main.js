function disableAsyncButton(btn, message = "Loading...") {
    btn.value = message;
    btn.disabled = true;
}

const getCurrentCity = (lat, lng) => {
    return new Promise((resolve, reject) => {
        var currentCity = null;
        var latlng = new google.maps.LatLng(lat, lng);

        try {
            new google.maps.Geocoder().geocode({ 'latLng': latlng }, function(results, status) {
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
            });
        } catch (error) {
            reject("Unknown")
        }
    });
};