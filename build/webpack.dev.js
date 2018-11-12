const path = require('path')
const merge = require('webpack-merge')
const entries = require('webpack-entries')
const configuration = require('./webpack.common')

function entries_reformatted() {
    let list = entries("./src/views/*.js", true)
    let result = {}
    for (let entry in list) {
        let directory = path.basename(path.dirname(list[entry]))
        result[path.join(directory, entry)] = list[entry]
    }

    return result
}

module.exports = merge(configuration, {
    mode: 'development',
    devtool: "#cheap-module-eval-source-map",
    entry: {
        ...entries_reformatted(),
        "styles": ["assets/scss/layout.scss"],
    },
    output: {
        path: path.resolve(__dirname, "../Application/wwwroot/"),
        filename: 'js/[name].js',
        publicPath: '/js/'
    },
})