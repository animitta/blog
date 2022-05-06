import path from "path";
import { defineConfig } from "vite";
import vue from "@vitejs/plugin-vue";
import viteSvgIcons from "vite-plugin-svg-icons";
import AutoImport from 'unplugin-auto-import/vite'
import Components from 'unplugin-vue-components/vite'
import { ElementPlusResolver } from 'unplugin-vue-components/resolvers'

export default defineConfig({
  plugins: [
    vue(),
    AutoImport({
      resolvers: [ElementPlusResolver()],
    }),
    Components({
      resolvers: [ElementPlusResolver()],
    }),
    viteSvgIcons({
      symbolId: "icon-[dir]-[name]",
      iconDirs: [path.resolve(__dirname, "src/icons/svgs")],
    }),
  ],
  resolve: {
    alias: {
      "@": path.resolve(__dirname, "src"),
      "@c": path.resolve(__dirname, "src/components"),
    },
  },
  server: {
    port: 80,
  },
});
