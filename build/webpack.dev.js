const path = require('path')
const merge = require('webpack-merge')
const entries = require('webpack-entries')
const configuration = require('./webpack.common')

function entryList() {

    let list = entries("./src/views/*.js", true)
    for (let entry in list) {
        let directory = path.basename(path.dirname(list[entry]))
        Object.defineProperty(list, path.join(directory, entry),
            Object.getOwnPropertyDescriptor(list, entry))
        delete list[entry]
    }

    return list
}

module.exports = merge(configuration, {
    mode: 'development',
    devtool: "#cheap-module-eval-source-map",
    entry: {
        ...entryList(),
        // TODO: Rasti alternatyvą šitam hakui.
        "css/styles.css": "assets/scss/layout.scss",
    },
    output: {
        path: path.resolve(__dirname, "../Application/wwwroot/"),
        filename: 'js/[name].js',
        publicPath: '/js/'
    },
})