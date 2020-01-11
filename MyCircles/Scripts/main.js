function disableAsyncButton(btn, message = "Loading...") {
    btn.value = message;
    btn.disabled = true;
}