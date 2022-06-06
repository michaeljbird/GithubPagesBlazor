export function getBlazorTheme() {
    return window.localStorage['SiteTheme'];
};

export function setBlazorTheme(value) {
    window.localStorage['SiteTheme'] = value;
};