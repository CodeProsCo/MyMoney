
function initializeGlobalObject() {
    window.myMoney = {
        strings: new LocalizedStringStore("/common/resource/{namespace}/{key}")
    };
}