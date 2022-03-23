// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function CastTime(time) {
    int t;
    if (time == 0) {
        t = this.Time;
    }
    else {
        t = (int)time;
    }

    if (t > 12) {
        t -= 12;
        return t.ToString() + ":00 PM";
    }
    else {
        return t.ToString() + ":00 AM";
    }
}