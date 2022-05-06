import { defineStore } from "pinia";

export interface SettingStore {
  dark: boolean;
}
const useSettingStore = defineStore({
  id: "setting",
  state: (): SettingStore => ({
    dark: false,
  }),
});

export const initSettingStore = () => {
  const instance = useSettingStore();
};

export default useSettingStore;
