(function () {
    window.CustomFunctions = {
        getDimensions: function() {
            return window.innerWidth;
        },
        getUserAgent: function(){
            return navigator.userAgent;
        },
        getCounterClass: function (statistics) {
            var miliseconds = 1000;

            var milisecondsAnimation = 0;

            var animations = statistics;

            const interval = setInterval(() => {
                milisecondsAnimation += 50;
                for (const counter of animations) {
                    if (milisecondsAnimation < miliseconds) {
                        counter.val = getRandomNumber(counter.minimum, counter.maximum);
                    } else {
                        counter.val = counter.maximum;
                    }
                }
                if (milisecondsAnimation >= miliseconds) {
                    clearInterval(interval);
                    setTimeout(() => {
                        milisecondsAnimation = 0;
                    },
                        100);
                }
                document.getElementById("animation0").innerHTML = animations[0].val.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
                document.getElementById("animation1").innerHTML = animations[1].val;
                document.getElementById("animation2").innerHTML = animations[2].val;
                document.getElementById("animation3").innerHTML = animations[3].val;
                document.getElementById("animation4").innerHTML = animations[4].val;
                document.getElementById("animation5").innerHTML = animations[5].val;
            }, 50);
        },
        getCookies: function () {
            return Cookies.get("cookiesAccepted") == 'YES' ? true : false;
        },
        setCookies: function () {
            Cookies.set('cookiesAccepted', 'YES', { expires: 365 });
        },
        scrollToFragment: function(elementId) {
            var element = document.getElementById(elementId);
            if (elementId) {
            const yOffset = -100;
            const y = element.getBoundingClientRect().top + window.pageYOffset + yOffset;
            if (element) {
                element.scrollIntoView({
                    top: y,
                    behavior: 'smooth'
                });
                }
            }
        },
        loadInvestor: function () {
            var graph1 = {
                "autosize": true,
                "symbol": "TSXV:APM",
                "timezone": "Etc/UTC",
                "theme": "light",
                "style": "3",
                "locale": "en",
                "toolbar_bg": "#f1f3f6",
                "enable_publishing": false,
                "withdateranges": true,
                "range": "1D",
                "allow_symbol_change": true,
                "save_image": false,
                "container_id": "tradingview_ec0ef"
            }

            new TradingView.widget(graph1);
        },
        triggerFileDownload: function (fileName, url) {
            const anchorElement = document.createElement('a');
            anchorElement.href = url;
            anchorElement.download = fileName ?? '';
            anchorElement.click();
            anchorElement.remove();
        }
    }
})();

function getRandomNumber(min, max) {
    return Math.floor(Math.random() * (max - min) + min);
}

function showLoader() {
    return true;
}

