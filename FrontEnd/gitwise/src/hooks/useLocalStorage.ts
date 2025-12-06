import { useCallback } from "react";

export const useLocalStorage = (key: string) => {
	const getItem = useCallback((defaultValue?: unknown) => {
		try {
			const item = window.localStorage.getItem(key);
			return item ? JSON.parse(item) : defaultValue;
		} catch (error) {
			console.error(`Error reading from localStorage: ${key}`, error);
			return defaultValue;
		}
	}, [key]);

	const setItem = useCallback((value: unknown) => {
		try {
			window.localStorage.setItem(key, JSON.stringify(value));
		} catch (error) {
			console.error(`Error writing to localStorage: ${key}`, error);
		}
	}, [key]);

	const removeItem = useCallback(() => {
		try {
			window.localStorage.removeItem(key);
		} catch (error) {
			console.error(`Error removing from localStorage: ${key}`, error);
		}
	}, [key]);

	return { getItem, setItem, removeItem };
};
