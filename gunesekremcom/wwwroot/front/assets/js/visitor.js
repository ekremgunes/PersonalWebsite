window.addEventListener("load", function () {
    const visitedBefore = localStorage.getItem('visitedbefore');
    const oneMinuteInMillis = 60000; 
    const now = new Date().getTime();

    if (!visitedBefore || now - new Date(visitedBefore).getTime() >= oneMinuteInMillis) {
        localStorage.setItem('visitedbefore', new Date(now).toISOString());

        fetch('/Home/IncreaseVisitor', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: true
        })
            .catch(error => {
            });

    }
}); 