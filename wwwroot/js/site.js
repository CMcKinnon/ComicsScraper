function imageErrorHandler(evt) {
    console.log(evt);
    this['src'] = '';
    this['onerror'] = null;
}