import { getToken } from "../utils/jwt-helper";
export const API_URLS = {
  GET_PRODUCTS: "/test/product",
  GET_PRODUCT: (id) => `/test/product/${id}`,
  GET_CATEGORIES: "/test/category",
  GET_CATEGORY: (id) => `/test/category/${id}`,
};

export const API_BASE_URL = "http://3.25.91.236:8088";

export const getHeaders = () => {
  return {
    Authorization: `Bearer ${getToken()}`,
  };
};
