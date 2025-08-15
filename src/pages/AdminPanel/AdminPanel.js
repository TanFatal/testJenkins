import React from "react";
import {
  Admin,
  fetchUtils,
  Resource,
  withLifecycleCallbacks,
} from "react-admin";
import simpleRestProvider from "ra-data-simple-rest";
import ProductList from "./ProductList";
import EditProduct from "./EditProduct";
import CreateProduct from "./CreateProduct";
import CategoryList from "./Category/CategoryList";
import CategoryEdit from "./Category/CategoryEdit";
import CreateCategory from "./Category/CreateCategory";
import { fileUploadAPI } from "../../api/fileUpload";

const httpClient = (url, options = {}) => {
  const token = localStorage.getItem("authToken");
  if (!options.headers) options.headers = new Headers();
  options.headers.set("Authorization", `Bearer ${token}`);
  return fetchUtils.fetchJson(url, options);
};
const dataProvider = withLifecycleCallbacks(
  simpleRestProvider("http://3.25.91.236:8088/test/api", httpClient),
  [
    {
      resource: "product",
      beforeSave: async (params, dataProvider) => {
        console.log("Params ", params);
        let requestBody = {
          ...params,
        };
        
        // Kiểm tra xem có phải là create hay update
        const isCreate = !params.id;
        console.log("Is Create:", isCreate);
        
        let productResList = params?.productResources ?? [];

        // Chỉ upload thumbnail nếu có file mới (rawFile)
        if (params?.thumbnail?.rawFile) {
          const fileName = params?.thumbnail?.rawFile?.name?.replaceAll(" ", "-");
          const formData = new FormData();
          formData.append("file", params?.thumbnail?.rawFile);
          formData.append("fileName", fileName);

          const thumbnailResponse = await fileUploadAPI(formData);
          requestBody.thumbnail = thumbnailResponse;
        } else {
          // Giữ nguyên thumbnail cũ nếu không có file mới
          requestBody.thumbnail = params.thumbnail;
        }

        // Xử lý product resources
        const newProductResList = await Promise.all(
          productResList?.map(async (productResource) => {
            // Chỉ upload nếu có rawFile (file mới)
            if (productResource?.url?.rawFile) {
              const fileName = productResource?.url?.rawFile?.name?.replaceAll(
                " ",
                "-"
              );
              const formData = new FormData();
              formData.append("file", productResource?.url?.rawFile);
              formData.append("fileName", fileName);
              const fileUploadRes = await fileUploadAPI(formData);
              return {
                ...productResource,
                url: fileUploadRes,
              };
            } else {
              // Giữ nguyên URL cũ nếu không có file mới
              return productResource;
            }
          })
        );

        const request = {
          ...requestBody,
          productResources: newProductResList,
        };
        console.log("Request Body ", request);
        return request;
      },
    },
  ]
);

export const AdminPanel = () => {
  return (
    <Admin dataProvider={dataProvider} basename="/admin">
      <Resource
        name="product"
        list={ProductList}
        edit={EditProduct}
        create={CreateProduct}
      />
      <Resource
        name="category"
        list={CategoryList}
        edit={CategoryEdit}
        create={CreateCategory}
      />
    </Admin>
  );
};
