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
        let productResList = params?.productResources ?? [];
        const fileName = params?.thumbnail?.rawFile?.name?.replaceAll(" ", "-");
        const formData = new FormData();
        formData.append("file", params?.thumbnail?.rawFile);
        formData.append("fileName", fileName);

        const thumbnailResponse = await fileUploadAPI(formData);
        requestBody.thumbnail = thumbnailResponse;

        const newProductResList = await Promise.all(
          productResList?.map(async (productResource) => {
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
          })
        );
        //console.log("Params ",params,fileName);
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
