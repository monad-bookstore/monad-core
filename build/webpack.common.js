const path = require('path')
const webpack = require('webpack')
const MiniCssExtractPlugin = require("mini-css-extract-plugin")
const VueLoaderPlugin = require('vue-loader/lib/plugin')
const CopyWebpackPlugin = require('copy-webpack-plugin')

module.exports = {
    resolve: {
        extensions: [".js", ".json", ".vue"],
        alias: {
            'vue$': 'vue/dist/vue.esm.js',
            '~': path.resolve(__dirname, '../src/'),
            'assets': path.resolve(__dirname),
            'components': path.resolve(__dirname, '../src/components')
        },
        modules: [
            path.resolve('./'),
            path.resolve('./node_modules')
        ],
    },
    optimization: {
        runtimeChunk: 'single',
        splitChunks: {
            cacheGroups: {
                vendors: {
                    test: /[\\/]node_modules[\\/]/,
                    name: 'vendors',
                    chunks: 'all',
                    enforce: true,
                },
                styles: {
                    test: /\.scss$/,
                    name: 'styles',
                    chunks: 'all',
                    enforce: true
                }
            }
        }
    },
    module: {
        /**
         * Kai kur galima matyti, kad yra naudojamas module.loaders, tačiau
         * ateity module.loaders taps nebepalaikomu (deprecated).
         */
        rules: [
            {
                test: /\.vue$/,
                loader: 'vue-loader'
            },
            {
                test: /\.scss$/,
                use: [
                    MiniCssExtractPlugin.loader,
                    "css-loader", 
                    {
                        loader: "sass-loader",
                        options: {
                            includePaths: [path.resolve(__dirname, '/scss/')]
                        }
                    },
                ]
            },
            {
                test: /\.css$/,
                use: [
                    MiniCssExtractPlugin.loader,
                    "css-loader"
                ]
            },
            {
                test: /\.(eot|ttf|woff|woff2)(\?\S*)?$/,
                use: [
                    {
                        loader: 'file-loader',
                        options: {
                            name: '[name].[ext]',
                            outputPath: '/fonts',
                            publicPath: '/fonts/'
                        }
                    }
                ]
            },
            {
                test: /\.(png|jpe?g|gif|svg)(\?\S*)?$/,
                use: [
                    {
                        loader: 'file-loader',
                        options: {
                            name: '[name].[ext]?[hash]',
                            outputPath: '/images',
                            publicPath: '/images/'
                        }
                    }
                ]
            }
        ]
    },
    plugins: ([
        new MiniCssExtractPlugin({
            filename: "/css/[name].css",
            chunkFilename: "/css/[id].css"
        }),
        new CopyWebpackPlugin([{
            from: 'node_modules/mdbootstrap/js', to: path.resolve(__dirname, "../Application/wwwroot", "lib", "mdbootstrap", "js"),
        }, {
            from: 'node_modules/mdbootstrap/css', to: path.resolve(__dirname, "../Application/wwwroot", "lib", "mdbootstrap", "css"),
        }]),
        new webpack.NoEmitOnErrorsPlugin(),
        new VueLoaderPlugin()
    ]),
    stats: { 
        colors: true 
    }
}