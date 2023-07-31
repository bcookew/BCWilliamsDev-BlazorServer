export function get(key) {
    return window.localStorage.getItem(key);
    
}

export function set(key, value) {
    try {
        window.localStorage.setItem(key, value);
        return true;
    }
    catch (error) {
        console.error(error)
        return false;
    }
}

export function remove(key) {
    window.localStorage.removeItem(key);
}